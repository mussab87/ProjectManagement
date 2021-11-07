// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 12-08-2019
// ***********************************************************************
// <copyright file="sr-Cyrl.js" company="Expert Systems">
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
/// <param name="u">The u.</param>
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
!function(){if(jQuery&&jQuery.fn&&jQuery.fn.select2&&jQuery.fn.select2.amd)var n=jQuery.fn.select2.amd;n.define("select2/i18n/sr-Cyrl",[],function(){function n(n,e,r,u){return n%10==1&&n%100!=11?e:n%10>=2&&n%10<=4&&(n%100<12||n%100>14)?r:u}return{errorLoading:function(){return"Преузимање није успело."},inputTooLong:function(e){var r=e.input.length-e.maximum,u="Обришите "+r+" симбол";return u+=n(r,"","а","а")},inputTooShort:function(e){var r=e.minimum-e.input.length,u="Укуцајте бар још "+r+" симбол";return u+=n(r,"","а","а")},loadingMore:function(){return"Преузимање још резултата…"},maximumSelected:function(e){var r="Можете изабрати само "+e.maximum+" ставк";return r+=n(e.maximum,"у","е","и")},noResults:function(){return"Ништа није пронађено"},searching:function(){return"Претрага…"},removeAllItems:function(){return"Уклоните све ставке"}}}),n.define,n.require}();