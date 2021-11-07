// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 12-08-2019
// ***********************************************************************
// <copyright file="ru.js" company="Expert Systems">
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
!function(){if(jQuery&&jQuery.fn&&jQuery.fn.select2&&jQuery.fn.select2.amd)var n=jQuery.fn.select2.amd;n.define("select2/i18n/ru",[],function(){function n(n,e,r,u){return n%10<5&&n%10>0&&n%100<5||n%100>20?n%10>1?r:e:u}return{errorLoading:function(){return"Невозможно загрузить результаты"},inputTooLong:function(e){var r=e.input.length-e.maximum,u="Пожалуйста, введите на "+r+" символ";return u+=n(r,"","a","ов"),u+=" меньше"},inputTooShort:function(e){var r=e.minimum-e.input.length,u="Пожалуйста, введите ещё хотя бы "+r+" символ";return u+=n(r,"","a","ов")},loadingMore:function(){return"Загрузка данных…"},maximumSelected:function(e){var r="Вы можете выбрать не более "+e.maximum+" элемент";return r+=n(e.maximum,"","a","ов")},noResults:function(){return"Совпадений не найдено"},searching:function(){return"Поиск…"},removeAllItems:function(){return"Удалить все элементы"}}}),n.define,n.require}();