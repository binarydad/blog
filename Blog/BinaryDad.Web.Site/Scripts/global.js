/// <reference path="jquery-2.1.4.js" />

(function ($) {

    var binarydad = {

        init: function () {

            // confirm dialogs
            $(document).on('click', '.confirm', function () {
                return confirm('Are you sure?');
            });

            // highlight.js
            $('pre').each(function (i, block) {
                hljs.highlightBlock(block);
            });
        }
    };

    window.binarydad = $.extend(window.binarydad || {}, binarydad);

})(jQuery);