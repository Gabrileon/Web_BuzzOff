function getPictureData(table, field, id) {
    var fileModel = {
        Table: table,
        Column: field,
        Id: id,
    };

    $.ajax({
        url: '/Files/GetPictureData',
        type: 'GET',
        data: fileModel,
        success: function (data) {
            document.getElementById('fotoDisplay').src = data.data;
        }
    });
}

function previewFoto() {
    var input = document.getElementById('uploadFoto');
    var preview = document.getElementById('fotoDisplay');
    var file = input.files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    };

// Write your JavaScript code