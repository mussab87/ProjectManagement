// ***********************************************************************
// Assembly         : Edu
// Author           : Ali Aljarrah && Walid Azouzi
// Created          : 02-23-2020
//
// Last Modified By : Ali Aljarrah && Walid Azouzi
// Last Modified On : 10-21-2019
// ***********************************************************************
// <copyright file="HijriDatePicker.js" company="Expert Systems">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
"use strict";
let picker = new Datepicker();
let pickElm = picker.getElement();
let pLeft = 200;
let pWidth = 300;
pickElm.style.position = "absolute";
pickElm.style.left = pLeft + "px";
pickElm.style.top = "172px";
picker.attachTo(document.body);

picker.onPicked = function() {
    /// <summary>
    /// </summary>
    let elgd = document.getElementById("gregDate");
    let elhd = document.getElementById("hijrDate");
    if (picker.getPickedDate() instanceof Date) {
        elgd.value = picker.getPickedDate().getDateString();
        elhd.value = picker.getOppositePickedDate().getDateString();
    } else {
        elhd.value = picker.getPickedDate().getDateString();
        elgd.value = picker.getOppositePickedDate().getDateString();
    }
};

function openSidebar() {
    /// <summary>
    /// Opens the sidebar.
    /// </summary>
    document.getElementById("mySidebar").style.display = "block";
}

function closeSidebar() {
    /// <summary>
    /// Closes the sidebar.
    /// </summary>
    document.getElementById("mySidebar").style.display = "none";
}

function dropdown(el) {
    /// <summary>
    /// Dropdowns the specified el.
    /// </summary>
    /// <param name="el">The el.</param>
    if (el.className.indexOf("expanded") == -1) {
        el.className = el.className.replace("collapsed", "expanded");
    } else {
        el.className = el.className.replace("expanded", "collapsed");
    }
}

function selectLang(el) {
    /// <summary>
    /// Selects the language.
    /// </summary>
    /// <param name="el">The el.</param>
    el.children[0].checked = true;
    picker.setLanguage(el.children[0].value);
}

function setFirstDay(fd) {
    /// <summary>
    /// Sets the first day.
    /// </summary>
    /// <param name="fd">The fd.</param>
    picker.setFirstDayOfWeek(fd);
}

function setYear() {
    /// <summary>
    /// Sets the year.
    /// </summary>
    let el = document.getElementById("valYear");
    picker.setFullYear(el.value);
}

function setMonth() {
    /// <summary>
    /// Sets the month.
    /// </summary>
    let el = document.getElementById("valMonth");
    picker.setMonth(el.value);
}

function updateWidth(el) {
    /// <summary>
    /// Updates the width.
    /// </summary>
    /// <param name="el">The el.</param>
    pWidth = parseInt(el.value);
    if (!fixWidth()) {
        document.getElementById("valWidth").value = pWidth;
        picker.setWidth(pWidth);
    }
}

function pickDate(ev) {
    /// <summary>
    /// Picks the date.
    /// </summary>
    /// <param name="ev">The ev.</param>
    ev = ev || window.event;
    let el = ev.target || ev.srcElement;
    pLeft = ev.pageX;
    fixWidth();
    pickElm.style.top = ev.pageY + "px";
    picker.setHijriMode(el.id == "hijrDate");
    picker.show();
    el.blur();
}

function gotoToday() {
    /// <summary>
    /// Gotoes the today.
    /// </summary>
    picker.today();
}

function setTheme() {
    /// <summary>
    /// Sets the theme.
    /// </summary>
    let el = document.getElementById("txtTheme");
    let n = parseInt(el.value);
    if (!isNaN(n)) picker.setTheme(n);
    else picker.setTheme(el.value);
}

function newTheme() {
    /// <summary>
    /// News the theme.
    /// </summary>
    picker.setTheme();
}

function fixWidth() {
    /// <summary>
    /// Fixes the width.
    /// </summary>
    let docWidth = document.body.offsetWidth;
    let isFixed = false;
    if (pLeft + pWidth > docWidth) pLeft = docWidth - pWidth;
    if (docWidth >= 992 && pLeft < 200) pLeft = 200;
    else if (docWidth < 992 && pLeft < 0) pLeft = 0;
    if (pLeft + pWidth > docWidth) {
        pWidth = docWidth - pLeft;
        picker.setWidth(pWidth);
        document.getElementById("valWidth").value = pWidth;
        document.getElementById("sliderWidth").value = pWidth;
        isFixed = true;
    }
    pickElm.style.left = pLeft + "px";
    return isFixed;
}