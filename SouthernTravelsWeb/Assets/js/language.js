﻿browserName = navigator.appName;
browserVer = parseInt(navigator.appVersion);
condition = !(((browserName.indexOf("Explorer") >= 0) && (browserVer < 4)) || ((browserName.indexOf("Netscape") >= 0) && (browserVer < 2)));
if (condition == true)
    CanAnimate = true;
else
    CanAnimate = false;

if (window.top !== window.self) { window.top.location = window.self.location; }


function convertnew(pattern) {

    /////////////////////////////////////////////////////////////
    // Script to use language convertor
    /////////////////////////////////////////////////////////////

    /// Configuration parameters //////////////
    var open_in_same_window = 1;
    //////////// End Of Configuration /////////////

    var my_location = unescape(document.location.toString());
    var new_location = '';
    var new_pattern = '';
    if (my_location.indexOf('translate_c?') != -1) {
        /// From google...
        var indexof_u = my_location.indexOf('&u=');
        if (indexof_u == -1) {
            new_location = document.location;
        }
        else {
            var subs = my_location.substring(indexof_u, my_location.length);
            var ss = subs.split('&');
            new_location = ss[1].substring(2, ss[1].length);
        }
    }
    else if (my_location.indexOf("babelfish") != -1) {
        var tmplocation = my_location.split('=');
        var tmpl = tmplocation[1];
        var tmploc2 = tmpl.split('&');
        new_location = tmploc2[0];
    } else {
        new_location = document.location;
    }

    indexof_p = pattern.indexOf('|');

    var isen = '';
    if (indexof_p == -1) {
        indexof_p1 = pattern.indexOf('><');
        if (indexof_p1 == -1) {
            new_pattern = pattern;
            if (pattern == 'en') {
                isen = 1;
            }
        }
        else {
            var psplit = pattern.split('><');
            new_pattern = psplit[0] + '|' + psplit[1];
            if (psplit[1] == 'en') {
                isen = 1;
            }
        }
    }
    else {
        var psplit = pattern.split('|');
        new_pattern = psplit[0] + '|' + psplit[1];
        if (psplit[1] == 'en') {
            isen = 1;
        }
    }



    var thisurl = '';
    if (isen == 1) {
        thisurl = new_location;
    }
    else {
        thisurl = 'http://translate.google.com/translate_c?langpair=' + new_pattern + "&u=" + new_location;
    }

    if (open_in_same_window == 1) {
        window.location.href = thisurl;
    }
    else {
        if (CanAnimate) {
            msgWindow = window.open('', 'subwindow', 'toolbar=yes,location=yes,directories=yes,status=yes,scrollbars=yes,menubar=yes,resizable=yes,left=0,top=0');
            msgWindow.focus();
            msgWindow.location.href = thisurl;
        }
        else {
            msgWindow = window.open(thisurl, 'subwindow', 'toolbar=yes,location=yes,directories=yes,status=yes,scrollbars=yes,menubar=yes,resizable=yes,left=0,top=0');
        }
    }
}