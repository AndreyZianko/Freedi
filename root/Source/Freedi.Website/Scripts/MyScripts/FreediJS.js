﻿$(document).ready(function () {
    var options = {};
   
    $('.js-uploader__box').uploader(options);

    var options = {
    submitButtonCopy: 'Upload Selected Files',
    instructionsCopy: 'Drag and Drop, or',
    furtherInstructionsCopy: 'Your can also drop more files, or',
    selectButtonCopy: 'Select Files',
    secondarySelectButtonCopy: 'Select More Files',
    dropZone: $(this),
    fileTypeWhiteList: ['jpg', 'png', 'jpeg', 'gif'],
    badFileTypeMessage: 'Sorry, we\'re unable to accept this type of file.',
    ajaxUrl: '/CreateProduct/CreateProduct',
    testMode: false

    };

});
