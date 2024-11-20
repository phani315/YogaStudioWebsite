$(document).ready(function () {
  loadInstructorDetails();

  loadClassDetails();
  $('#btnAddClass').on('click', function(event) {
    event.preventDefault();
    debugger;

    var name = $("#className").val();
    var classLevel = $("#classLevel").val();

    var instructorId = 1;
    var startDate = $("#startDate").val();
    var cancellationDeadline = $("#Cancellation").val();

    var endDate = $("#endDate").val();
    var startTime = $("#startTime").val();
    var endTime = $("#endTime").val();
    var maxCapacity = $("#maxCapacity").val();
    var price = $("#price").val();
    var description = $("#description").val();

    $.ajax({
      url:
        apiBaseUrl +
        `AddClass?Name=${name}&InstructorId=${1}&StartTime=${startTime}&EndTime=${endTime}&ClassDateForm=${startDate}&MaxCapacity=${maxCapacity}&CurrentCapacity=0&WaitingList=0&Description=${description}&ClassDateTo=${endDate}&Price=${price}&ClassLevel=${classLevel}&CancellationDeadline=${cancellationDeadline}`,
      type: "POST",
      success: function (response) {
        console.log("Class added successfully");
        $("#addClassModal").modal("hide");
        Swal.fire("Success!", "Your class has been added.", "success");
        // Call a function to refresh the class details table
        loadClassDetails();
      },
      error: function (xhr, status, error) {
        Swal.fire("Failed!", "Failed to add class.", "error");
        console.error("Error adding class:", error,startDate,xhr);
      },
    });
  });
});
function loadClassDetails() {
  $.ajax({
    url: apiBaseUrl + "GetAllClasses",
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
          { data: "description" },
          { data: "price" },
          {
            data: null,
            render: function (data, type, row) {
              return `
                                <button class="btn btn-subtle-primary btn-sm" data-bs-toggle="modal" data-bs-target="#editClassModal" onclick="editClass(${row.classId}, '${row.name}', ${row.instructorId}, '${row.classDateForm}', '${row.classDateTo}', '${row.startTime}', '${row.endTime}', ${row.maxCapacity}, '${row.description}', '${row.price}')">
                                    <i class="bi bi-pencil-square"></i> Edit
                                </button>
                                <button class="btn btn-subtle-danger btn-sm" onclick="deleteClass(${row.classId})">
                                    <i class="bi bi-trash3 text-danger"></i> Delete
                                </button>`;
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

function deleteClass(classId) {
  Swal.fire({
    title: "Are you sure?",
    text: "You will not be able to recover this class once deleted!",
    icon: "question",
    showCancelButton: true,
    confirmButtonColor: "#d33",
    cancelButtonColor: "#3085d6",
    confirmButtonText: "Yes, delete it!",
  }).then((result) => {
    if (result.isConfirmed) {
      // User confirmed, make delete AJAX call
      $.ajax({
        url: apiBaseUrl+`RemoveClass?ClassId=${classId}`,
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

function editClass(
  classId,
  className,
  instructorId,
  startDate,
  endDate,
  startTime,
  endTime,
  maxCapacity,
  description,
  price
) {
  // Populate the modal with class data
  $("#editClassName").val(className);
  $("#editInstructor").val(instructorId);
  $("#editStartDate").val(startDate);
  $("#editEndDate").val(endDate);
  $("#editStartTime").val(startTime);
  $("#editEndTime").val(endTime);
  $("#editMaxCapacity").val(maxCapacity);
  $("#editDescription").val(description);
  $("#editPrice").val(price);

  // Show the modal
  $("#editClassModal").modal("show");

  // Save changes button click event
  $("#btnEditClass")
    .off("click")
    .on("click", function () {
      // Update the class object with the new data
      var classData = {
        classId: classId,
        className: $("#editClassName").val(),
        instructorId: $("#editInstructor").val(),
        startDate: $("#editStartDate").val(),
        endDate: $("#editEndDate").val(),
        startTime: $("#editStartTime").val(),
        endTime: $("#editEndTime").val(),
        maxCapacity: $("#editMaxCapacity").val(),
        description: $("#editDescription").val(),
        price: $("#editPrice").val(),
      };

      // Make a PUT AJAX call to update the class
      $.ajax({
        url: "your-api-url/" + classData.classId,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(classData),
        success: function (response) {
          // Handle success response
          console.log("Class updated successfully");
          // Close the modal
          $("#editClassModal").modal("hide");
        },
        error: function (xhr, status, error) {
          // Handle error response
          console.error("Error updating class:", error);
        },
      });
    });
}

function loadInstructorDetails() {
  $.ajax({
    url: apiBaseUrl + "GetAllInstructor",
    type: "GET",
    dataType: "json",
    success: function (instructorsData) {
      // Populate the select element with instructor options
      var instructorSelect = $("#instructor");
      instructorSelect.empty(); // Clear existing options

      $.each(instructorsData, function (index, instructor) {
        instructorSelect.append(
          $("<option>", {
            value: instructor.instructor_id,
            text: instructor.name,
          })
        );
      });
    },
    error: function (xhr, status, error) {
      console.error("Failed to load instructor data:", error);
    },
  });
}
