// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 10-15-2019
// ***********************************************************************
// <copyright file="jquery.rowspanizer.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/*!
 * jQuery Rowspanizer Plugin v0.1
 * https://github.com/marcosesperon/jquery.rowspanizer.js
 *
 * Copyright 2011, 2015 Marcos Esperón
 * Released under the MIT license
 * 
 * https://github.com/jquery-boilerplate/boilerplate/
 */

; (function ($, window, document, undefined) {

    /// <summary>
    /// </summary>
    /// <param name="$">The $.</param>
    /// <param name="window">The window.</param>
    /// <param name="document">The document.</param>
    /// <param name="undefined">The undefined.</param>
    "use strict";

    var rowspanizer = "rowspanizer",
        defaults = {
            vertical_align: "top"
        };

    function f(element, options) {

        /// <summary>
        /// fs the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="options">The options.</param>
        this.element = element;

        this.settings = $.extend({}, defaults, options);
        this._defaults = defaults;
        this._name = rowspanizer;
        this.init();

    }

    $.extend(f.prototype, {
        init: function () {

            /// <summary>
            /// </summary>
            var _this = this;

            var $table = $(this.element);
            var arr = [];

            $table.find('tr').each(function (r, tr) {
                /// <summary>
                /// </summary>
                /// <param name="r">The r.</param>
                /// <param name="tr">The tr.</param>
                $(this).find('td').each(function (d, td) {
                    /// <summary>
                    /// </summary>
                    /// <param name="d">The d.</param>
                    /// <param name="td">The td.</param>
                    var $td = $(td);
                    var v_dato = $td.html();
                    if (typeof arr[d] != 'undefined' && 'dato' in arr[d] && arr[d].dato == v_dato) {
                        var rs = arr[d].elem.data('rowspan');
                        if (rs == 'undefined' || isNaN(rs)) rs = 1;
                        arr[d].elem.data('rowspan', parseInt(rs) + 1).addClass('rowspan-combine');
                        $td.addClass('rowspan-remove');
                    } else {
                        arr[d] = { dato: v_dato, elem: $td };
                    };
                });
            });

            $('.rowspan-combine').each(function (r, tr) {
                /// <summary>
                /// </summary>
                /// <param name="r">The r.</param>
                /// <param name="tr">The tr.</param>
                var $this = $(this);
                $this.attr('rowspan', $this.data('rowspan')).css({ 'vertical-align': _this.settings.vertical_align });
            });

            $('.rowspan-remove').remove();

        }
    });

    $.fn[rowspanizer] = function (options) {
        /// <summary>
        /// </summary>
        /// <param name="options">The options.</param>
        return this.each(function () {
            /// <summary>
            /// </summary>
            if (!$.data(this, "plugin_" + rowspanizer)) {
                $.data(this, "plugin_" +
                    rowspanizer, new f(this, options));
            }
        });
    };

})(jQuery, window, document);