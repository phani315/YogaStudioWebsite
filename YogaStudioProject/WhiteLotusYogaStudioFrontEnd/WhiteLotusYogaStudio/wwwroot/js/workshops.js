$(document).ready(function() {
    
   
loadWorkshopDetails();
loadInstructorDetails();




    
$('#addWorkshopForm').submit(function(e) {
    e.preventDefault(); // Prevent the form from submitting

    // Get the form data
    var name = $('#className').val();
    var instructorId = 1;
    var startDate = $('#startDate').val();
    var registrationDeadline = $('#registrationDeadline').val();
    var startTime = $('#startTime').val();
    var endTime = $('#endTime').val();
    var prerequisites = $('#Prerequsites').val();
    var maxCapacity = $('#maxCapacity').val();
    var price = $('#price').val();
    var equipmentRequired = $('#Equipment').val();
    var cancellationDeadline = $('#Cancellation').val();

    // Make the AJAX call to add the workshop
    $.ajax({
        url: apiBaseUrl+`AddWorkshop?Name=${name}&InstructorID=${instructorId}&StartTime=${startTime}&EndTime=${endTime}&Description=""&Price=${price}&Prerequisites=${prerequisites}&EquipmentRequired=${equipmentRequired}&RegistrationDeadline=${registrationDeadline}&MaxCapacity=${maxCapacity}&CurrentCapacity=0&CancellationDeadline=${cancellationDeadline}`,
        type: 'POST',
        success: function(response) {
            console.log('Workshop added successfully:', response);
            $('#addWorkshopModal').modal('hide');
            Swal.fire(
                'Added!',
                'Your workshop has been added.',
                'success'
            );
            loadWorkshopDetails(); // Reload workshop details after adding
        },
        error: function(xhr, status, error) {
            console.error('Error adding workshop:', error);
            Swal.fire(
                'Failed!',
                'Failed adding the workshop.',
                'error'
            );
        }
    });
});

});

function loadInstructorDetails() {
    $.ajax({
        url: apiBaseUrl + 'GetAllInstructor',
        type: 'GET',
        dataType: 'json',
        success: function (instructorsData) {
            // Populate the select element with instructor options
            var instructorSelect = $('#instructor');
            instructorSelect.empty(); // Clear existing options

            $.each(instructorsData, function(index, instructor) {
                instructorSelect.append($('<option>', {
                    value: instructor.instructor_id,
                    text: instructor.name
                }));
            });
        },
        error: function (xhr, status, error) {
            console.error('Failed to load instructor data:', error);
        }
    });
}

function loadWorkshopDetails() {
    $.ajax({
        url: apiBaseUrl + 'GetAllWorkshops',
        type: 'GET',
        dataType: 'json',
        success: function (workshopsData) {
            var table = $('#workshopDetailsTable').DataTable({
                destroy: true,
                data: workshopsData,
                columns: [
                    { data: 'name' },
                    { data: 'instructorID' },
                    // { data: 'start_date' },
                    { data: 'registrationDeadline' },
                    { data: 'startTime' },
                    { data: 'endTime' },
                    { data: 'prerequisites' },
                    { data: 'maxCapacity' },
                    { data: 'price' },
                    { data: 'equipmentRequired' },
                    {
                        data: null,
                        render: function (data, type, row) {
                            return `
                            <button class="btn btn-subtle-primary btn-sm" onclick="editWorkshop(${row.workshopId}, '${row.name}', ${row.instructorID}, '${row.startTime}', '${row.endTime}', '${row.description}', ${row.price}, '${row.prerequisites}', '${row.equipmentRequired}', '${row.registrationDeadline}', ${row.maxCapacity}, ${row.currentCapacity}, '${row.cancellationDeadline}')"
                            data-bs-toggle="modal" data-bs-target="#editWorkshopModal">
                                    <i class="bi bi-pencil-square"></i> Edit
                                </button>
                                <button class="btn btn-subtle-danger btn-sm" onclick="deleteWorkshop(${row.workshopId})">
                                    <i class="bi bi-trash3 text-danger"></i> Delete
                                </button>`;
                        }
                    }
                ],
                columnDefs: [],
                scrollX: true, // Enable horizontal scrolling
                autoWidth: false // Disable automatic column width calculation
            });
        },
        error: function (xhr, status, error) {
            console.error('Failed to load workshop data:', error);
        }
    });
}



function editWorkshop(workshopId, name, instructorId, startDate, regDeadline, startTime, endTime, prerequisites, maxCapacity, price, equipment, cancellationDeadline) {
    // Populate the modal with workshop data
    debugger
    $('#editClassName').val(name);
    $('#editInstructor').val(instructorId);
    $('#editStartDate').val(startDate);
    $('#editRegDeadline').val(regDeadline);
    $('#editStartTime').val(startTime);
    $('#editEndTime').val(endTime);
    $('#editPrerequisites').val(prerequisites);
    $('#editMaxCapacity').val(maxCapacity);
    $('#editPrice').val(price);
    $('#editEquipment').val(equipment);
    $('#editCancellation').val(cancellationDeadline);

    // Show the modal
    $('#editWorkshopModal').modal('show');

    // Save changes button click event
    $('#btnEditWorkshop').off('click').on('click', function() {
        // Call the updateWorkshop function with the updated data
        updateWorkshop(workshopId, $('#editClassName').val(), $('#editInstructor').val(), $('#editStartDate').val(), $('#editRegDeadline').val(), $('#editStartTime').val(), $('#editEndTime').val(), $('#editPrerequisites').val(), $('#editMaxCapacity').val(), $('#editPrice').val(), $('#editEquipment').val(), $('#editCancellation').val());
    });
}

function updateWorkshop(workshopId, name, instructorId, startDate, regDeadline, startTime, endTime, prerequisites, maxCapacity, price, equipment, cancellationDeadline) {
    // Make a PUT AJAX call to update the workshop
    $.ajax({
        url: apiBaseUrl + `UpdateWorkshop?WorkshopId=${workshopId}&Name=${name}&InstructorID=${instructorId}&StartTime=${startTime}&EndTime=${endTime}&Description=${description}&Price=${price}&Prerequisites=${prerequisites}&EquipmentRequired=${equipment}&RegistrationDeadline=${regDeadline}&MaxCapacity=${maxCapacity}&CurrentCapacity=${currentCapacity}&CancellationDeadline=${cancellationDeadline}`,
        type: 'POST',
        success: function(response) {
            console.log('Workshop updated successfully');
            // Close the modal
            $('#editWorkshopModal').modal('hide');
            Swal.fire(
                'Updated!',
                'Your workshop has been Updated.',
                'success'
            );
            loadWorkshopDetails(); // Assuming this function reloads the workshop details table
        },
        error: function(xhr, status, error) {
            Swal.fire(
                'Failed!',
                'Your workshop Update failed.',
                'Error'
            );
            console.error('Error updating workshop:', error);
        }
    });
}


function deleteWorkshop(workshopId) {
    Swal.fire({
      title: "Are you sure?",
      text: "You will not be able to recover this Workshop once deleted!",
      icon: "question",
      showCancelButton: true,
      confirmButtonColor: "#d33",
      cancelButtonColor: "#3085d6",
      confirmButtonText: "Yes, delete it!",
    }).then((result) => {
      if (result.isConfirmed) {
        // User confirmed, make delete AJAX call
        $.ajax({
          url: apiBaseUrl+`RemoveWorkshop?WorkshopId=${workshopId}`,
          type: "POST",
          success: function (response) {
            // Handle success response
            Swal.fire("Deleted!", "Your Class has been deleted.", "success");
            // Reload or update your class list here
          },
          error: function (xhr, status, error) {
            // Handle error response
            Swal.fire("Error!", "Failed to delete class.", "error");
          },
        });
      }
    });
  }
  