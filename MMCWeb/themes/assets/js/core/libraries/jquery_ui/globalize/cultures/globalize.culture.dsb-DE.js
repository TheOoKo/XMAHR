/*
 * Globalize Culture dsb-DE
 *
 * http://github.com/jquery/globalize
 *
 * Copyright Software Freedom Conservancy, Inc.
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/licence
 *
 * This file was generated by the Globalize Culture Generator
 * Translation: bugs found in this file need to be fixed in the generator
 */

(function( window, undefined ) {

var Globalize;

if ( typeof require !== "undefined" &&
	typeof exports !== "undefined" &&
	typeof module !== "undefined" ) {
	// Assume CommonJS
	Globalize = require( "globalize" );
} else {
	// Global variable
	Globalize = window.Globalize;
}

Globalize.addCultureInfo( "dsb-DE", "default", {
	name: "dsb-DE",
	englishName: "Lower Sorbian (Germany)",
	nativeName: "dolnoserbšćina (Nimska)",
	language: "dsb",
	numberFormat: {
		",": ".",
		".": ",",
		"NaN": "njedefinowane",
		negativeInfinity: "-njekońcne",
		positiveInfinity: "+njekońcne",
		percent: {
			",": ".",
			".": ","
		},
		currency: {
			pattern: ["-n $","n $"],
			",": ".",
			".": ",",
			symbol: "€"
		}
	},
	calendars: {
		standard: {
			"/": ". ",
			firstDay: 1,
			days: {
				names: ["njeźela","ponjeźele","wałtora","srjoda","stwortk","pětk","sobota"],
				namesAbbr: ["nje","pon","wał","srj","stw","pět","sob"],
				namesShort: ["n","p","w","s","s","p","s"]
			},
			months: {
				names: ["januar","februar","měrc","apryl","maj","junij","julij","awgust","september","oktober","nowember","december",""],
				namesAbbr: ["jan","feb","měr","apr","maj","jun","jul","awg","sep","okt","now","dec",""]
			},
			monthsGenitive: {
				names: ["januara","februara","měrca","apryla","maja","junija","julija","awgusta","septembra","oktobra","nowembra","decembra",""],
				namesAbbr: ["jan","feb","měr","apr","maj","jun","jul","awg","sep","okt","now","dec",""]
			},
			AM: null,
			PM: null,
			eras: [{"name":"po Chr.","start":null,"offset":0}],
			patterns: {
				d: "d. M. yyyy",
				D: "dddd, 'dnja' d. MMMM yyyy",
				t: "H.mm 'goź.'",
				T: "H:mm:ss",
				f: "dddd, 'dnja' d. MMMM yyyy H.mm 'goź.'",
				F: "dddd, 'dnja' d. MMMM yyyy H:mm:ss",
				M: "d. MMMM",
				Y: "MMMM yyyy"
			}
		}
	}
});

}( this ));
