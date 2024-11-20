$(document).ready(function() {
   
    
    loadInstructorDetails()
    
$('#addInstructorForm').submit(function(e) {
    e.preventDefault(); // Prevent the form from submitting
    
    // Get the form data
    var name = $('#Name').val();
    var email = $('#email').val();
    var phoneNumber = $('#PhoneNumber').val();
    var yearsOfExperience = $('#yearsOfExperience').val();
    
    // Call the addInstructor function with the form data
    addInstructor(name, email, phoneNumber, yearsOfExperience);
});

})

function loadInstructorDetails() {
    $.ajax({
        url: apiBaseUrl + 'GetAllInstructor',
        crossDomain: true, // Add this line to enable cross-domain requests
        type: 'GET',
        dataType: 'json',
        success: function (instructorsData) {
            if ($.fn.DataTable.isDataTable("#instructorDetailsTable")) {
                // DataTable is already initialized, destroy it before reinitializing
                $("#instructorDetailsTable").DataTable().destroy();
            }
            var table = $('#instructorDetailsTable').DataTable({
                data: instructorsData,
                columns: [
                    { data: 'name' },
                    { data: 'email' },
                    { data: 'ph_num' },
                    { data: 'yearOfExperience' },
                    {
                        data: null,
                        render: function (data, type, row) {
                            return `
                            <button class="btn btn-subtle-primary btn-sm" data-bs-toggle="modal" data-bs-target="#editInstructorModal" onclick="editInstructor('${row.instructorID}', '${row.name}', '${row.email}', '${row.ph_num}', '${row.yearOfExperience}')">
                            <i class="bi bi-pencil-square"></i> Edit
                                </button>
                                <button class="btn btn-subtle-danger btn-sm" onclick="deleteInstructor(${row.instructorID})">
                                    <i class="bi bi-trash3 text-danger"></i> Delete
                                </button>`;
                        }
                    }
                ],
                scrollX: true, // Enable horizontal scrolling
                autoWidth: false // Disable automatic column width calculation
            });
        },
        error: function (xhr, status, error) {
            console.error('Failed to load instructor data:', error);
        }
    });
}


function deleteInstructor(instructorId) {
    Swal.fire({
        title: 'Are you sure?',
        text: 'You will not be able to recover this Instructor once deleted!',
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            // User confirmed, make delete AJAX call
            $.ajax({
                url: apiBaseUrl+`RemoveInstructor?InstructorID=${instructorId}`,
                type: 'POST',
                success: function (response) {
                    // Handle success response
                    Swal.fire(
                        'Deleted!',
                        'Your Instructor has been deleted.',
                        'success'
                    );
loadInstructorDetails()                },
                error: function (xhr, status, error) {
                    // Handle error response
                    Swal.fire(
                        'Error!',
                        'Failed to delete Instructor.',
                        'error'
                    );
                }
            });
        }
    });
}



function addInstructor(name, email, phoneNumber, yearsOfExperience) {
    debugger
    var url = apiBaseUrl + `AddInstructor?StudioId=${1}&Name=${name}&Email=${email}&Ph_num=${phoneNumber}&YearOfExperience=${yearsOfExperience}`;
    
    $.ajax({
        url: url,
        type: 'POST',
        success: function(response) {
            // Handle success response
            console.log('Instructor added successfully:', response);
            $('#addInstructorModal').modal('hide');
            Swal.fire(
                'Added!',
                'Your instructor has been added.',
                'success'
            );
            loadInstructorDetails();
        },
        error: function(error) {
            // Handle error response
            Swal.fire(
                'Failed!',
                'Failed adding the instructor.',
                'error'
            );
            console.error('Error adding instructor:', error);
            // Handle error, show error message, etc.
        }
    });
}




function editInstructor(instructorId, name, email, phoneNumber, yearsOfExperience) {
    // Populate the modal with instructor data
    $('#editName').val(name);
    $('#editEmail').val(email);
    $('#editPhoneNumber').val(phoneNumber);
    $('#editYearsOfExperience').val(yearsOfExperience);

    // Show the modal
    $('#editInstructorModal').modal('show');

    // Save changes button click event
    $('#btnEditInstructor').off('click').on('click', function() {
        // Call the updateInstructor function with the updated data
        updateInstructor(instructorId, $('#editName').val(), $('#editEmail').val(), $('#editPhoneNumber').val(), $('#editYearsOfExperience').val());
    });
}

function updateInstructor(instructorId, name, email, phoneNumber, yearsOfExperience) {
    // Make a PUT AJAX call to update the instructor
    $.ajax({
        url: apiBaseUrl+`UpdateInstructor?StudioId=${1}&InstructorID=${instructorId}&Name=${name}&Email=${email}&Ph_num=${phoneNumber}&YearOfExperience=${yearsOfExperience}`,
        type: 'POST',
        success: function(response) {
            console.log('Instructor updated successfully');
            // Close the modal
            $('#editInstructorModal').modal('hide');
            Swal.fire(
                'Updated!',
                'Your instructor has been Updated.',
                'success'
            );
            loadInstructorDetails();
        },
        error: function(xhr, status, error) {
            Swal.fire(
                'Failed!',
                'Your instructor Update failed.',
                'Error'
            );
            console.error('Error updating instructor:', error);
        }
    });
}

// $('#editInstructorForm').submit(function(e) {
//     e.preventDefault(); // Prevent the form from submitting
//     // Get the form data
//     var instructorId = 1; // Assuming the instructorId is hardcoded for now
//     var name = $('#editName').val();
//     var email = $('#editEmail').val();
//     var phoneNumber = $('#editPhoneNumber').val();
//     var yearsOfExperience = $('#editYearsOfExperience').val();
//     // Call the updateInstructor function with the form data
//     updateInstructor(instructorId, name, email, phoneNumber, yearsOfExperience);
// });
