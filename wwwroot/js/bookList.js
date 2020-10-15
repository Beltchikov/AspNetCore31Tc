var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    var bookData;

    $.ajax("/api/book",
        {
            success: function (data, textStatus, jqXHR) {
                bookData = data.data.result;
            }
        }).done(function () {
            dataTable = $('#DT_load').DataTable({
                data: bookData,
                columns: [
                    { data: "name", width: "20%" },
                    { data: "author", width: "20%" },
                    { data: "isbn", width: "20%" },
                    {data: "id",
                    render: function (data) {
                        return `<div class="text-center">
<a href="BookList/Edit?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:70px;"  >  
Edit
</a>
&nbsp;
<a class="btn btn-danger text-white" style="cursor:pointer; width:70px;"  >  
Delete
</a>
</div>`
                    },
                    width: "20%"}],
                language: {
                "emptyTable": "no data found"
            },
                width: "100%"
            });
});

    
}
