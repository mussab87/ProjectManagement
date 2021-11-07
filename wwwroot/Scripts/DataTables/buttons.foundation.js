// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 10-15-2019
// ***********************************************************************
// <copyright file="buttons.foundation.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/*! Foundation integration for DataTables' Buttons
 * ©2016 SpryMedia Ltd - datatables.net/license
 */

(function( factory ){
	/// <summary>
	/// </summary>
	/// <param name="factory">The factory.</param>
	if ( typeof define === 'function' && define.amd ) {
		// AMD
		define( ['jquery', 'datatables.net-zf', 'datatables.net-buttons'], function ( $ ) {
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

			if ( ! $.fn.dataTable.Buttons ) {
				require('datatables.net-buttons')(root, $);
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


// F6 has different requirements for the dropdown button set. We can use the
// Foundation version found by DataTables in order to support both F5 and F6 in
// the same file, but not that this requires DataTables 1.10.11+ for F6 support.
var collection = DataTable.ext.foundationVersion === 6 ?
	{
		tag: 'div',
		className: 'dt-button-collection dropdown-pane is-open button-group stacked'
	} :
	{
		tag: 'ul',
		className: 'dt-button-collection f-dropdown open dropdown-pane is-open',
		button: {
			tag: 'li',
			className: 'small'
		},
		buttonLiner: {
			tag: 'a'
		}
	};

$.extend( true, DataTable.Buttons.defaults, {
	dom: {
		container: {
			tag: 'div',
			className: 'dt-buttons button-group'
		},
		buttonContainer: {
			tag: null,
			className: ''
		},
		button: {
			tag: 'a',
			className: 'button small'
		},
		buttonLiner: {
			tag: null
		},
		collection: collection
	}
} );


DataTable.ext.buttons.collection.className = 'buttons-collection dropdown';


return DataTable.Buttons;
}));
