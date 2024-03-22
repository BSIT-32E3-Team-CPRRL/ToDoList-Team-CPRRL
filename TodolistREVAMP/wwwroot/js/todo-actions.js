
function markAsCompleted(itemId) {
    $.ajax({
        url: '/Todo/MarkAsCompleted/' + itemId,
        type: 'POST',
        success: function (response) {

            $('#task_' + itemId).fadeOut('slow', function () {
                $(this).remove(); 
            });
        },
        error: function (xhr, status, error) {

            console.error(xhr.responseText);
        }
    });
}




// Function to delete a task
function deleteTask(itemId) {
    $.ajax({
        url: '/Todo/Delete/' + itemId,
        type: 'POST',
        success: function (response) {

            $('#task_' + itemId).fadeOut('slow', function () {
                $(this).remove();
            });
        },
        error: function (xhr, status, error) {
 
            console.error(xhr.responseText);
        }
    });
}
