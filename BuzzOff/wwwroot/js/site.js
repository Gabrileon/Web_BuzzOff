// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "/img/userIcon.svg"; // Imagem padrão se nenhum arquivo for selecionado
    }
}