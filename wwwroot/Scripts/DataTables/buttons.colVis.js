// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 10-15-2019
// ***********************************************************************
// <copyright file="buttons.colVis.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/*!
 * Column visibility buttons for Buttons and DataTables.
 * 2016 SpryMedia Ltd - datatables.net/license
 */

(function( factory ){
	/// <summary>
	/// </summary>
	/// <param name="factory">The factory.</param>
	if ( typeof define === 'function' && define.amd ) {
		// AMD
		define( ['jquery', 'datatables.net', 'datatables.net-buttons'], function ( $ ) {
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
				$ = require('datatables.net')(root, $).$;
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


$.extend( DataTable.ext.buttons, {
	// A collection of column visibility buttons
	colvis: function ( dt, conf ) {
		/// <summary>
		/// </summary>
		/// <param name="dt">The dt.</param>
		/// <param name="conf">The conf.</param>
		return {
			extend: 'collection',
			text: function ( dt ) {
				/// <summary>
				/// </summary>
				/// <param name="dt">The dt.</param>
				return dt.i18n( 'buttons.colvis', 'Column visibility' );
			},
			className: 'buttons-colvis',
			buttons: [ {
				extend: 'columnsToggle',
				columns: conf.columns,
				columnText: conf.columnText
			} ]
		};
	},

	// Selected columns with individual buttons - toggle column visibility
	columnsToggle: function ( dt, conf ) {
		/// <summary>
		/// </summary>
		/// <param name="dt">The dt.</param>
		/// <param name="conf">The conf.</param>
		var columns = dt.columns( conf.columns ).indexes().map( function ( idx ) {
			/// <summary>
			/// </summary>
			/// <param name="idx">The index.</param>
			return {
				extend: 'columnToggle',
				columns: idx,
				columnText: conf.columnText
			};
		} ).toArray();

		return columns;
	},

	// Single button to toggle column visibility
	columnToggle: function ( dt, conf ) {
		/// <summary>
		/// </summary>
		/// <param name="dt">The dt.</param>
		/// <param name="conf">The conf.</param>
		return {
			extend: 'columnVisibility',
			columns: conf.columns,
			columnText: conf.columnText
		};
	},

	// Selected columns with individual buttons - set column visibility
	columnsVisibility: function ( dt, conf ) {
		/// <summary>
		/// </summary>
		/// <param name="dt">The dt.</param>
		/// <param name="conf">The conf.</param>
		var columns = dt.columns( conf.columns ).indexes().map( function ( idx ) {
			/// <summary>
			/// </summary>
			/// <param name="idx">The index.</param>
			return {
				extend: 'columnVisibility',
				columns: idx,
				visibility: conf.visibility,
				columnText: conf.columnText
			};
		} ).toArray();

		return columns;
	},

	// Single button to set column visibility
	columnVisibility: {
		columns: undefined, // column selector
		text: function ( dt, button, conf ) {
			/// <summary>
			/// </summary>
			/// <param name="dt">The dt.</param>
			/// <param name="button">The button.</param>
			/// <param name="conf">The conf.</param>
			return conf._columnText( dt, conf );
		},
		className: 'buttons-columnVisibility',
		action: function ( e, dt, button, conf ) {
			/// <summary>
			/// </summary>
			/// <param name="e">The e.</param>
			/// <param name="dt">The dt.</param>
			/// <param name="button">The button.</param>
			/// <param name="conf">The conf.</param>
			var col = dt.columns( conf.columns );
			var curr = col.visible();

			col.visible( conf.visibility !== undefined ?
				conf.visibility :
				! (curr.length ? curr[0] : false )
			);
		},
		init: function ( dt, button, conf ) {
			/// <summary>
			/// </summary>
			/// <param name="dt">The dt.</param>
			/// <param name="button">The button.</param>
			/// <param name="conf">The conf.</param>
			var that = this;

			dt
				.on( 'column-visibility.dt'+conf.namespace, function (e, settings) {
					/// <summary>
					/// </summary>
					/// <param name="e">The e.</param>
					/// <param name="settings">The settings.</param>
					if ( ! settings.bDestroying ) {
						that.active( dt.column( conf.columns ).visible() );
					}
				} )
				.on( 'column-reorder.dt'+conf.namespace, function (e, settings, details) {
					// Don't rename buttons based on column name if the button
					// controls more than one column!
					/// <summary>
					/// </summary>
					/// <param name="e">The e.</param>
					/// <param name="settings">The settings.</param>
					/// <param name="details">The details.</param>
					if ( dt.columns( conf.columns ).count() !== 1 ) {
						return;
					}

					if ( typeof conf.columns === 'number' ) {
						conf.columns = details.mapping[ conf.columns ];
					}

					var col = dt.column( conf.columns );

					that.text( conf._columnText( dt, conf ) );
					that.active( col.visible() );
				} );

			this.active( dt.column( conf.columns ).visible() );
		},
		destroy: function ( dt, button, conf ) {
			/// <summary>
			/// </summary>
			/// <param name="dt">The dt.</param>
			/// <param name="button">The button.</param>
			/// <param name="conf">The conf.</param>
			dt
				.off( 'column-visibility.dt'+conf.namespace )
				.off( 'column-reorder.dt'+conf.namespace );
		},

		_columnText: function ( dt, conf ) {
			// Use DataTables' internal data structure until this is presented
			// is a public API. The other option is to use
			// `$( column(col).node() ).text()` but the node might not have been
			// populated when Buttons is constructed.
			/// <summary>
			/// </summary>
			/// <param name="dt">The dt.</param>
			/// <param name="conf">The conf.</param>
			var idx = dt.column( conf.columns ).index();
			var title = dt.settings()[0].aoColumns[ idx ].sTitle
				.replace(/\n/g," ")        // remove new lines
				.replace( /<.*?>/g, "" )   // strip HTML
				.replace(/^\s+|\s+$/g,""); // trim

			return conf.columnText ?
				conf.columnText( dt, idx, title ) :
				title;
		}
	},


	colvisRestore: {
		className: 'buttons-colvisRestore',

		text: function ( dt ) {
			/// <summary>
			/// </summary>
			/// <param name="dt">The dt.</param>
			return dt.i18n( 'buttons.colvisRestore', 'Restore visibility' );
		},

		init: function ( dt, button, conf ) {
			/// <summary>
			/// </summary>
			/// <param name="dt">The dt.</param>
			/// <param name="button">The button.</param>
			/// <param name="conf">The conf.</param>
			conf._visOriginal = dt.columns().indexes().map( function ( idx ) {
				/// <summary>
				/// </summary>
				/// <param name="idx">The index.</param>
				return dt.column( idx ).visible();
			} ).toArray();
		},

		action: function ( e, dt, button, conf ) {
			/// <summary>
			/// </summary>
			/// <param name="e">The e.</param>
			/// <param name="dt">The dt.</param>
			/// <param name="button">The button.</param>
			/// <param name="conf">The conf.</param>
			dt.columns().every( function ( i ) {
				// Take into account that ColReorder might have disrupted our
				// indexes
				/// <summary>
				/// </summary>
				/// <param name="i">The i.</param>
				var idx = dt.colReorder && dt.colReorder.transpose ?
					dt.colReorder.transpose( i, 'toOriginal' ) :
					i;

				this.visible( conf._visOriginal[ idx ] );
			} );
		}
	},


	colvisGroup: {
		className: 'buttons-colvisGroup',

		action: function ( e, dt, button, conf ) {
			/// <summary>
			/// </summary>
			/// <param name="e">The e.</param>
			/// <param name="dt">The dt.</param>
			/// <param name="button">The button.</param>
			/// <param name="conf">The conf.</param>
			dt.columns( conf.show ).visible( true, false );
			dt.columns( conf.hide ).visible( false, false );

			dt.columns.adjust();
		},

		show: [],

		hide: []
	}
} );


return DataTable.Buttons;
}));
