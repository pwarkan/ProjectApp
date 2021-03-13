//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();

    $('#btnAdd').click(function () {
        var data = GetData();
        Add(data);
    });

    $('#btnUpdate').click(function () {
        var data = GetData();
        Update(data);
    });
});


//Load Data function  
function loadData() {
    $.ajax({
        url: "/car",
        type: "GET",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.brand + '</td>';
                html += '<td>' + item.price + '</td>';
                html += '<td><a href="#" onclick="getbyID(' + item.id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function GetData() {
    var data = {};
    data.id = $('#Id').val();
    data.name = $('#Name').val();
    data.brand = $('#Brand').val();
    data.price = $('#Price').val();
    return data;
}

//Add Data Function   
function Add(data) {
    clearTextBox();
    $.ajax({
        url: "/car",
        data: data,
        type: "POST",
        dataType: "json"
    }).done(function (result) {
        loadData();
        $('#myModal').modal('hide');
    }).fail(function (errormessage) {
        alert(errormessage.responseText);
        loadData();
    });
}

//Function for getting the Data Based upon ID  
function getbyID(objId) {
    $('#Id').attr("disabled", true);
    $('#Id').css('border-color', 'lightgrey');
    $('#Id').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#Brand').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
    $.ajax({
        url: "/car/" + objId,
        typr: "GET",
        dataType: "json"
    }).done(function (result) {
        $('#Id').val(result.id);
        $('#Name').val(result.name);
        $('#Brand').val(result.brand);
        $('#Price').val(result.price);

        $('#myModal').modal('show');
        $('#btnUpdate').show();
        $('#btnAdd').hide();
    }).fail(function (errormessage) {
        alert(errormessage.responseText);
        loadData();
    });
}

//function for updating employee's record  
function Update(data) {
    $.ajax({
        type: "PUT",
        url: "/car",
        data: data,
        dataType: "json"
    }).done(function (result) {
        loadData();
        $('#myModal').modal('hide');
    }).fail(function (errormessage) {
        alert(errormessage.responseText);
        loadData();
    });
}

//function for deleting employee's record  
function Delele(id) {
    $.ajax({
        url: "/car/" + id,
        type: "DELETE",
        dataType: "json"
    }).done(loadData).fail(function (errormessage) {
        alert(errormessage.responseText);
        loadData();
    });
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#Id').attr("disabled", false);
    $('#Id').val("");
    $('#Name').val("");
    $('#Brand').val("");
    $('#Price').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Id').css('border-color', 'lightgrey');
    $('#Brand').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
}