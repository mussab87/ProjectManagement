// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 10-15-2019
// ***********************************************************************
// <copyright file="responsive.foundation.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/*! Foundation integration for DataTables' Responsive
 * ©2015 SpryMedia Ltd - datatables.net/license
 */

(function( factory ){
	/// <summary>
	/// </summary>
	/// <param name="factory">The factory.</param>
	if ( typeof define === 'function' && define.amd ) {
		// AMD
		define( ['jquery', 'datatables.net-zf', 'datatables.net-responsive'], function ( $ ) {
			/// <summary>
			/// </summary>
			/// <param name="$">The $.</param>
			return factory( $, window, document );
		} );
	}
	else if ( typeof exports === 'object' ) {
		// CommonJS
		module.exports = function (root, $) {
			/// <summary>
			/// </summary>
			/// <param name="root">The root.</param>
			/// <param name="$">The $.</param>
			if ( ! root ) {
				root = window;
			}

			if ( ! $ || ! $.fn.dataTable ) {
				$ = require('datatables.net-zf')(root, $).$;
			}

			if ( ! $.fn.dataTable.Responsive ) {
				require('datatables.net-responsive')(root, $);
			}

			return factory( $, root, root.document );
		};
	}
	else {
		// Browser
		factory( jQuery, window, document );
	}
}(function( $, window, document, undefined ) {
/// <summary>
/// </summary>
/// <param name="$">The $.</param>
/// <param name="window">The window.</param>
/// <param name="document">The document.</param>
/// <param name="undefined">The undefined.</param>
'use strict';
var DataTable = $.fn.dataTable;


var _display = DataTable.Responsive.display;
var _original = _display.modal;

_display.modal = function ( options ) {
	/// <summary>
	/// </summary>
	/// <param name="options">The options.</param>
	return function ( row, update, render ) {
		/// <summary>
		/// </summary>
		/// <param name="row">The row.</param>
		/// <param name="update">The update.</param>
		/// <param name="render">The render.</param>
		if ( ! $.fn.foundation ) {
			_original( row, update, render );
		}
		else {
			if ( ! update ) {
				$( '<div class="reveal-modal" data-reveal/>' )
					.append( '<a class="close-reveal-modal" aria-label="Close">&#215;</a>' )
					.append( options && options.header ? '<h4>'+options.header( row )+'</h4>' : null )
					.append( render() )
					.appendTo( 'body' )
					.foundation( 'reveal', 'open' );
			}
		}
	};
};


return DataTable.Responsive;
}));
