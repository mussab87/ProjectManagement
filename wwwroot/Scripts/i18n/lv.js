// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 12-08-2019
// ***********************************************************************
// <copyright file="lv.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/*! Select2 4.0.11 | https://github.com/select2/select2/blob/master/LICENSE.md */

/// <summary>
/// </summary>
/// <summary>
/// </summary>
/// <summary>
/// es the specified e.
/// </summary>
/// <param name="e">The e.</param>
/// <param name="n">The n.</param>
/// <param name="u">The u.</param>
/// <param name="i">The i.</param>
/// <summary>
/// </summary>
/// <param name="n">The n.</param>
/// <summary>
/// </summary>
/// <param name="n">The n.</param>
/// <summary>
/// </summary>
/// <summary>
/// </summary>
/// <param name="n">The n.</param>
/// <summary>
/// </summary>
/// <summary>
/// </summary>
/// <summary>
/// </summary>
!function(){if(jQuery&&jQuery.fn&&jQuery.fn.select2&&jQuery.fn.select2.amd)var e=jQuery.fn.select2.amd;e.define("select2/i18n/lv",[],function(){function e(e,n,u,i){return 11===e?n:e%10==1?u:i}return{inputTooLong:function(n){var u=n.input.length-n.maximum,i="Lūdzu ievadiet par  "+u;return(i+=" simbol"+e(u,"iem","u","iem"))+" mazāk"},inputTooShort:function(n){var u=n.minimum-n.input.length,i="Lūdzu ievadiet vēl "+u;return i+=" simbol"+e(u,"us","u","us")},loadingMore:function(){return"Datu ielāde…"},maximumSelected:function(n){var u="Jūs varat izvēlēties ne vairāk kā "+n.maximum;return u+=" element"+e(n.maximum,"us","u","us")},noResults:function(){return"Sakritību nav"},searching:function(){return"Meklēšana…"},removeAllItems:function(){return"Noņemt visus vienumus"}}}),e.define,e.require}();