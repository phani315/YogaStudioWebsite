$(document).ready(function () {
  
    loadRegisteredClassDetails();
 
  });
  function loadRegisteredClassDetails() {
    $.ajax({
      url: apiClientURL + "GetRegisteredClasses?ClientId=16",
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
                            <button class="btn btn-subtle-danger btn-sm" onclick="cancelClass(${row.classId})">
                                <i class="bi bi-x-circle text-danger"></i> Cancel
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
  

  function cancelClass(classId) {
    swal.fire({
        title: 'Are you sure?',
        text: 'Once canceled, you will not be able to recover this class!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Yes, cancel it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: apiClientURL+`cancelworkshoporclass?Id=${classId}&ClientId=16&Type=class`,
                type: 'POST',
                
                success: function (response) {
                    // Handle success response
                    swal.fire('Canceled!', 'Your class has been canceled.', 'success');
                    // Refresh class details table
                    loadRegisteredClassDetails();
                },
                error: function (xhr, status, error) {
                    // Handle error response
                    swal.fire('Error!', 'Failed to cancel class.', 'error');
                }
            });
        }
    });
}