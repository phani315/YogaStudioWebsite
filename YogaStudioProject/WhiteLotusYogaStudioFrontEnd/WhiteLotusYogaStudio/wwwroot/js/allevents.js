$(document).ready(function () {
  
    loadRegisteredClassDetails();
    loadAllWorkshopDetails()
  });
  function loadRegisteredClassDetails() {
    $.ajax({
      url: apiClientURL + "Getallclasses?ClientId=16",
      type: "GET",
      success: function (response) {
        if ($.fn.DataTable.isDataTable("#classDetailsTable")) {
          // DataTable is already initialized, destroy it before reinitializing
          $("#classDetailsTable").DataTable().destroy();
        }
        var table = $("#classDetailsTable").DataTable({
          data: response,
          columns: [
            { data: "name" },
            { data: "instructorId" },
            { data: "classDateForm" },
            { data: "classDateTo" },
            { data: "startTime" },
            { data: "endTime" },
            { data: "maxCapacity" },
            // { data: "description" },
            { data: "price" },
            {
                data: null,
                render: function (data, type, row) {
                    var currentDate = new Date();
                    var startDate = new Date(row.classDateForm);
                    if (startDate >= currentDate) {
                        return `
                            <button class="btn btn-success " onclick="registerClass(${row.classId})">
                                 Register
                            </button>`;
                    } else {
                        return '';
                    }
                },
            },
            
            
          ],
          columnDefs: [
            { width: "20%", targets: 7 }, // Set width of Description column to 20%
          ],
          scrollX: true, // Enable horizontal scrolling
          autoWidth: false, // Disable automatic column width calculation
        });
      },
      error: function (xhr, status, error) {
        console.error("Error loading class details:", error);
      },
    });
  }
  

  function registerClass(classId) {
    swal.fire({
        title: 'Are you sure?',
        text: '',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, Register for it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: apiClientURL+`RegsterClass?ClassId=${classId}&ClientId=16`,
                type: 'POST',
                
                success: function (response) {
                    // Handle success response
                    swal.fire('Registered!', 'You have been Registered.', 'success');
                    // Refresh class details table
                    loadRegisteredClassDetails();
                },
                error: function (xhr, status, error) {
                    // Handle error response
                    swal.fire('Error!', 'Failed to register class.', 'error');
                }
            });
        }
    });
}


function loadAllWorkshopDetails() {
    $.ajax({
        url: apiBaseUrl + 'Getallworkshops?ClientId=16',
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
                    // { data: 'registrationDeadline' },
                    { data: 'startTime' },
                    { data: 'endTime' },
                    { data: 'prerequisites' },
                    { data: 'maxCapacity' },
                    { data: 'price' },
                    { data: 'equipmentRequired' },
                    {
                        data: null,
                        render: function (data, type, row) {
                            // var currentDate = new Date();
                            // var startDate = new Date(row.classDateForm);
                            // if (startDate >= currentDate) {
                                return `
                                    <button class="btn btn-subtle-success btn-sm" onclick="registerWorkshop(${row.workshopId})">
                                         Register
                                    </button>`;
                            // } else {
                            //     return '';
                            // }
                        },
                    },
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


function registerWorkshop(classId) {
    swal.fire({
        title: 'Are you sure?',
        text: '',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, Register for it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: apiClientURL+`RegsterWorkshop?ClassId=${classId}&ClientId=16
                `,
                type: 'POST',
                
                success: function (response) {
                    // Handle success response
                    swal.fire('Registered!', 'You have been Registered.', 'success');
                    // Refresh class details table
                    loadAllWorkshopDetails();
                },
                error: function (xhr, status, error) {
                    // Handle error response
                    swal.fire('Error!', 'Failed to register class.', 'error');
                }
            });
        }
    });
}
