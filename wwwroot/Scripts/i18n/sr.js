// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 12-08-2019
// ***********************************************************************
// <copyright file="sr.js" company="Expert Systems">
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
/// ns the specified n.
/// </summary>
/// <param name="n">The n.</param>
/// <param name="e">The e.</param>
/// <param name="r">The r.</param>
/// <param name="t">The t.</param>
/// <summary>
/// </summary>
/// <summary>
/// </summary>
/// <param name="e">The e.</param>
/// <summary>
/// </summary>
/// <param name="e">The e.</param>
/// <summary>
/// </summary>
/// <summary>
/// </summary>
/// <param name="e">The e.</param>
/// <summary>
/// </summary>
/// <summary>
/// </summary>
/// <summary>
/// </summary>
!function(){if(jQuery&&jQuery.fn&&jQuery.fn.select2&&jQuery.fn.select2.amd)var n=jQuery.fn.select2.amd;n.define("select2/i18n/sr",[],function(){function n(n,e,r,t){return n%10==1&&n%100!=11?e:n%10>=2&&n%10<=4&&(n%100<12||n%100>14)?r:t}return{errorLoading:function(){return"Preuzimanje nije uspelo."},inputTooLong:function(e){var r=e.input.length-e.maximum,t="Obrišite "+r+" simbol";return t+=n(r,"","a","a")},inputTooShort:function(e){var r=e.minimum-e.input.length,t="Ukucajte bar još "+r+" simbol";return t+=n(r,"","a","a")},loadingMore:function(){return"Preuzimanje još rezultata…"},maximumSelected:function(e){var r="Možete izabrati samo "+e.maximum+" stavk";return r+=n(e.maximum,"u","e","i")},noResults:function(){return"Ništa nije pronađeno"},searching:function(){return"Pretraga…"},removeAllItems:function(){return"Уклоните све ставке"}}}),n.define,n.require}();