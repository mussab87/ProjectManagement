// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 10-15-2019
// ***********************************************************************
// <copyright file="dataTables.rowGroup.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/*! RowGroup 1.0.0
 * ©2017 SpryMedia Ltd - datatables.net/license
 */

/**
 * @summary     RowGroup
 * @description RowGrouping for DataTables
 * @version     1.0.0
 * @file        dataTables.rowGroup.js
 * @author      SpryMedia Ltd (www.sprymedia.co.uk)
 * @contact     datatables.net
 * @copyright   Copyright 2017 SpryMedia Ltd.
 *
 * This source file is free software, available under the following license:
 *   MIT license - http://datatables.net/license/mit
 *
 * This source file is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE. See the license files for details.
 *
 * For details please refer to: http://www.datatables.net
 */

(function( factory ){
	/// <summary>
	/// </summary>
	/// <param name="factory">The factory.</param>
	if ( typeof define === 'function' && define.amd ) {
		// AMD
		define( ['jquery', 'datatables.net'], function ( $ ) {
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


var RowGroup = function ( dt, opts ) {
	// Sanity check that we are using DataTables 1.10 or newer
	/// <summary>
	/// </summary>
	/// <param name="dt">The dt.</param>
	/// <param name="opts">The opts.</param>
	if ( ! DataTable.versionCheck || ! DataTable.versionCheck( '1.10.8' ) ) {
		throw 'RowGroup requires DataTables 1.10.8 or newer';
	}

	// User and defaults configuration object
	this.c = $.extend( true, {},
		DataTable.defaults.rowGroup,
		RowGroup.defaults,
		opts
	);

	// Internal settings
	this.s = {
		dt: new DataTable.Api( dt ),

		dataFn: DataTable.ext.oApi._fnGetObjectDataFn( this.c.dataSrc ),
	};

	// DOM items
	this.dom = {

	};

	// Check if row grouping has already been initialised on this table
	var settings = this.s.dt.settings()[0];
	var existing = settings.rowGroup;
	if ( existing ) {
		return existing;
	}

	settings.rowGroup = this;
	this._constructor();
};


$.extend( RowGroup.prototype, {
	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * API methods for DataTables API interface
	 */

	/**
	 * Get/set the grouping data source - need to call draw after this is
	 * executed as a setter
	 * @returns string~RowGroup
	 */
	dataSrc: function ( val )
	{
		/// <summary>
		/// </summary>
		/// <param name="val">The value.</param>
		if ( val === undefined ) {
			return this.c.dataSrc;
		}

		var dt = this.s.dt;

		this.c.dataSrc = val;
		this.s.dataFn = DataTable.ext.oApi._fnGetObjectDataFn( this.c.dataSrc );

		$(dt.table().node()).triggerHandler( 'rowgroup-datasrc.dt', [ dt, val ] );

		return this;
	},

	/**
	 * Disable - need to call draw after this is executed
	 * @returns RowGroup
	 */
	disable: function ()
	{
		/// <summary>
		/// </summary>
		this.c.enable = false;
		return this;
	},

	/**
	 * Enable - need to call draw after this is executed
	 * @returns RowGroup
	 */
	enable: function ( flag )
	{
		/// <summary>
		/// </summary>
		/// <param name="flag">The flag.</param>
		if ( flag === false ) {
			return this.disable();
		}

		this.c.enable = true;
		return this;
	},


	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Constructor
	 */
	_constructor: function ()
	{
		/// <summary>
		/// </summary>
		var that = this;
		var dt = this.s.dt;

		dt.on( 'draw.dtrg', function () {
			/// <summary>
			/// </summary>
			if ( that.c.enable ) {
				that._draw();
			}
		} );

		dt.on( 'column-visibility.dtrg', function () {
			/// <summary>
			/// </summary>
			that._adjustColspan();
		} );

		dt.on( 'destroy', function () {
			/// <summary>
			/// </summary>
			dt.off( '.dtrg' );
		} );
	},


	/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
	 * Private methods
	 */

	/**
	 * Adjust column span when column visibility changes
	 * @private
	 */
	_adjustColspan: function ()
	{
		/// <summary>
		/// </summary>
		$( 'tr.'+this.c.className, this.s.dt.table().body() )
			.attr( 'colspan', this._colspan() );
	},

	/**
	 * Get the number of columns that a grouping row should span
	 * @private
	 */
	_colspan: function ()
	{
		/// <summary>
		/// </summary>
		return $( this.s.dt.columns().header() ).filter(':visible').length;
	},

	/**
	 * Update function that is called whenever we need to draw the grouping rows
	 * @private
	 */
	_draw: function ()
	{
		/// <summary>
		/// </summary>
		var that = this;
		var dt = this.s.dt;
		var rows = dt.rows( { page: 'current' } );
		var groupedRows = [];
		var last, display;

		rows.every( function () {
			/// <summary>
			/// </summary>
			var d = this.data();
			var group = that.s.dataFn( d );

			if ( last === undefined || group !== last ) {
				groupedRows.push( [] );
				last = group;
			}
			
			groupedRows[ groupedRows.length - 1 ].push( this.index() );
		} );

		for ( var i=0, ien=groupedRows.length ; i<ien ; i++ ) {
			var group = groupedRows[i];
			var firstRow = dt.row(group[0]);
			var groupName = this.s.dataFn( firstRow.data() );

			if ( this.c.startRender ) {
				display = this.c.startRender.call( this, dt.rows(group), groupName );
				
				this
					._rowWrap( display, this.c.startClassName )
					.insertBefore( firstRow.node() );
			}

			if ( this.c.endRender ) {
				display = this.c.endRender.call( this, dt.rows(group), groupName );
				
				this
					._rowWrap( display, this.c.endClassName )
					.insertAfter( dt.row( group[ group.length-1 ] ).node() );
			}
		}
	},

	/**
	 * Take a rendered value from an end user and make it suitable for display
	 * as a row, by wrapping it in a row, or detecting that it is a row.
	 * @param [node|jQuery|string] display Display value
	 * @param [string] className Class to add to the row
	 * @private
	 */
	_rowWrap: function ( display, className )
	{
		/// <summary>
		/// </summary>
		/// <param name="display">The display.</param>
		/// <param name="className">Name of the class.</param>
		var row;
		
		if ( typeof display === 'object' && display.nodeName && display.nodeName.toLowerCase() === 'tr') {
			row = $(display);
		}
		else if (display instanceof $ && display.length && display[0].nodeName.toLowerCase() === 'tr') {
			row = display;
		}
		else {
			row = $('<tr/>')
				.append(
					$('<td/>')
						.attr( 'colspan', this._colspan() )
						.append( display  )
				);
		}

		return row
			.addClass( this.c.className )
			.addClass( className );
	}
} );


/**
 * RowGroup default settings for initialisation
 *
 * @namespace
 * @name RowGroup.defaults
 * @static
 */
RowGroup.defaults = {
	/**
	 * Class to apply to grouping rows - applied to both the start and
	 * end grouping rows.
	 * @type string
	 */
	className: 'group',

	/**
	 * Data property from which to read the grouping information
	 * @type string|integer
	 */
	dataSrc: 0,

	/**
	 * Initial enablement state
	 * @boolean
	 */
	enable: true,

	/**
	 * Class name to give to the end grouping row
	 * @type string
	 */
	endClassName: 'group-end',

	/**
	 * End grouping label function
	 * @function
	 */
	endRender: null,

	/**
	 * Class name to give to the start grouping row
	 * @type string
	 */
	startClassName: 'group-start',

	/**
	 * Start grouping label function
	 * @function
	 */
	startRender: function ( rows, group ) {
		/// <summary>
		/// </summary>
		/// <param name="rows">The rows.</param>
		/// <param name="group">The group.</param>
		return group;
	}
};


RowGroup.version = "1.0.0";


$.fn.dataTable.RowGroup = RowGroup;
$.fn.DataTable.RowGroup = RowGroup;


DataTable.Api.register( 'rowGroup()', function () {
	/// <summary>
	/// </summary>
	return this;
} );

DataTable.Api.register( 'rowGroup().disable()', function () {
	/// <summary>
	/// </summary>
	return this.iterator( 'table', function (ctx) {
		/// <summary>
		/// </summary>
		/// <param name="ctx">The CTX.</param>
		if ( ctx.rowGroup ) {
			ctx.rowGroup.enable( false );
		}
	} );
} );

DataTable.Api.register( 'rowGroup().enable()', function ( opts ) {
	/// <summary>
	/// </summary>
	/// <param name="opts">The opts.</param>
	return this.iterator( 'table', function (ctx) {
		/// <summary>
		/// </summary>
		/// <param name="ctx">The CTX.</param>
		if ( ctx.rowGroup ) {
			ctx.rowGroup.enable( opts === undefined ? true : opts );
		}
	} );
} );

DataTable.Api.register( 'rowGroup().dataSrc()', function ( val ) {
	/// <summary>
	/// </summary>
	/// <param name="val">The value.</param>
	if ( val === undefined ) {
		return this.context[0].rowGroup.dataSrc();
	}

	return this.iterator( 'table', function (ctx) {
		/// <summary>
		/// </summary>
		/// <param name="ctx">The CTX.</param>
		if ( ctx.rowGroup ) {
			ctx.rowGroup.dataSrc( val );
		}
	} );
} );


// Attach a listener to the document which listens for DataTables initialisation
// events so we can automatically initialise
$(document).on( 'preInit.dt.dtrg', function (e, settings, json) {
	/// <summary>
	/// </summary>
	/// <param name="e">The e.</param>
	/// <param name="settings">The settings.</param>
	/// <param name="json">The json.</param>
	if ( e.namespace !== 'dt' ) {
		return;
	}

	var init = settings.oInit.rowGroup;
	var defaults = DataTable.defaults.rowGroup;

	if ( init || defaults ) {
		var opts = $.extend( {}, defaults, init );

		if ( init !== false ) {
			new RowGroup( settings, opts  );
		}
	}
} );


return RowGroup;

}));
