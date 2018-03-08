(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
'use strict'
/*eslint-env browser */

module.exports = {
  /**
   * Create a <style>...</style> tag and add it to the document head
   * @param {string} cssText
   * @param {object?} options
   * @return {Element}
   */
  createStyle: function (cssText, options) {
    var container = document.head || document.getElementsByTagName('head')[0]
    var style = document.createElement('style')
    options = options || {}
    style.type = 'text/css'
    if (options.href) {
      style.setAttribute('data-href', options.href)
    }
    if (style.sheet) { // for jsdom and IE9+
      style.innerHTML = cssText
      style.sheet.cssText = cssText
    }
    else if (style.styleSheet) { // for IE8 and below
      style.styleSheet.cssText = cssText
    }
    else { // for Chrome, Firefox, and Safari
      style.appendChild(document.createTextNode(cssText))
    }
    if (options.prepend) {
      container.insertBefore(style, container.childNodes[0]);
    } else {
      container.appendChild(style);
    }
    return style
  }
}

},{}],2:[function(require,module,exports){
(function (global){
"use strict";

require("./ng-horizontal-timeline.scss");

var _angular = (typeof window !== "undefined" ? window['angular'] : typeof global !== "undefined" ? global['angular'] : null);

var _angular2 = _interopRequireDefault(_angular);

var _jquery = (typeof window !== "undefined" ? window['$'] : typeof global !== "undefined" ? global['$'] : null);

var _jquery2 = _interopRequireDefault(_jquery);

var _timeline = require("./timeline");

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

//@ts-check
var appModule = _angular2.default.module("ng-horizontal-timeline", []);

function controller($element, $log, $timeout, $scope) {
    $log.debug("ng-horizontal-timeline component created.");
    var vm = this;

    vm.$onInit = function () {
        $log.debug("ng-horizontal-timeline component initialized.");

        _angular2.default.forEach(vm.events, function (ev) {
            var defaultObj = {
                selected: false,
                text: null
            };

            for (var propDef in defaultObj) {
                if (_angular2.default.isUndefined(ev[propDef])) {
                    ev[propDef] = defaultObj[ev[propDef]];
                }
            }
        });
    };

    vm.$postLink = function () {
        $log.debug("$postLink: ", (0, _jquery2.default)($element), vm.events);

        $timeout(function () {
            // initialize timeline
            vm.timeline = new _timeline.Timeline((0, _jquery2.default)($element).find(".timeline-container"));

            _resetSelected();

            // adds jQuery's event wrapper
            vm.timeline.onEventClick(_eventClick);
        });
    };

    $scope.$watch(function () {
        return vm.selectedIndex;
    }, function (_, newSelected) {
        if (_angular2.default.isUndefined(newSelected)) {
            return;
        }

        var i = 0;

        _angular2.default.forEach(vm.events, function (ev) {
            ev.selected = newSelected === i;
            i++;
        });

        $timeout(function () {
            return _resetSelectedStyle();
        });
    });

    $scope.$watchCollection(function () {
        return vm.events;
    }, function () {
        return $timeout(function () {
            vm.timeline.offEventClick(_eventClick);
            vm.timeline.onEventClick(_eventClick);
        });
    });

    function _resetSelected() {
        vm.selectedIndex = _getSelected(vm.events).index;
        _resetSelectedStyle();
    }

    function _resetSelectedStyle() {
        if (_angular2.default.isUndefined(vm.selectedIndex)) {
            return;
        }

        // add the style to the selected index
        vm.timeline.setSelected(vm.selectedIndex);
    }

    function _getSelected(events) {
        var eventSelected = null,
            i = 0,
            eventIndex = -1;

        _angular2.default.forEach(events, function (ev) {
            if (ev.selected) {
                eventSelected = ev;
                eventIndex = i;
            }
            i++;
        });

        return { obj: eventSelected, index: eventIndex };
    }

    function _eventClick(event) {
        $log.debug("clicked: ", event);

        if (vm.eventClick) {
            vm.eventClick(event);
        }

        _tryApplyScope();
    }

    function _tryApplyScope() {
        try {
            $scope.$apply();
        } catch (e) {
            $log.debug(e);
        }
    }

    return vm;
}

controller.$inject = ["$element", "$log", "$timeout", "$scope"];

var componentConfig = {
    controllerAs: "vm",
    controller: controller,
    bindings: {
        events: "=*",
        eventClick: '&?',
        selectedIndex: '='
    },
    template: "<div class=\"timeline-container\">\n    <ol class=\"timeline-events\">\n        <li class=\"timeline-event\" ng-repeat=\"event in vm.events\">\n            <a class=\"timeline-event-link\" href=\"#{{ $index }}\" ng-class=\"{ 'selected': event.selected }\">\n                <p ng-bind=\"event.text\"></p>\n            </a>\n        </li>\n    </ol>\n    <div class=\"line-container\">\n        <span class=\"filling-line\" aria-hidden=\"true\"></span>\n    </div>\n</div>"
};

appModule.component("hTimeline", componentConfig);

module.exports = appModule.name;

}).call(this,typeof global !== "undefined" ? global : typeof self !== "undefined" ? self : typeof window !== "undefined" ? window : {})

},{"./ng-horizontal-timeline.scss":3,"./timeline":4}],3:[function(require,module,exports){
var css = ".timeline-container {\n  position: relative; }\n  .timeline-container ol {\n    list-style: none;\n    display: -webkit-box;\n    display: -ms-flexbox;\n    display: flex;\n    padding: 0;\n    -webkit-box-pack: justify;\n        -ms-flex-pack: justify;\n            justify-content: space-between; }\n    .timeline-container ol li {\n      -webkit-box-orient: vertical;\n      -webkit-box-direction: normal;\n          -ms-flex-direction: column;\n              flex-direction: column;\n      height: 10px; }\n      .timeline-container ol li a {\n        text-decoration: none;\n        cursor: pointer;\n        display: block; }\n        .timeline-container ol li a::before {\n          top: 50%;\n          -webkit-transform: translateY(-50%);\n                  transform: translateY(-50%);\n          display: block;\n          position: absolute;\n          content: ' ';\n          width: 7px;\n          height: 7px;\n          background-color: #f8f8f8;\n          border: 1px solid #383838;\n          border-radius: 50%; }\n        .timeline-container ol li a.selected::before {\n          background-color: #7b9d6f;\n          border: none;\n          width: 10px;\n          height: 10px; }\n        .timeline-container ol li a p {\n          position: absolute;\n          display: block;\n          padding: 0;\n          width: 50px;\n          margin: 14px auto auto 0;\n          -webkit-transform: translateX(-40%);\n                  transform: translateX(-40%);\n          text-align: center;\n          text-wrap: normal;\n          overflow-wrap: break-word;\n          word-wrap: break-word;\n          -webkit-hyphens: auto;\n              -ms-hyphens: auto;\n                  hyphens: auto; }\n  .timeline-container .line-container {\n    display: block;\n    position: absolute;\n    top: 50%;\n    width: 100%; }\n    .timeline-container .line-container .filling-line {\n      display: block;\n      position: relative;\n      z-index: -1;\n      height: 1px;\n      background-color: #7b9d6f;\n      top: 50%;\n      -webkit-transform: translateY(-50%);\n              transform: translateY(-50%);\n      -webkit-transform: scaleX(0);\n              transform: scaleX(0);\n      -webkit-transform-origin: left center;\n              transform-origin: left center;\n      -webkit-transition: -webkit-transform 0.3s;\n      transition: -webkit-transform 0.3s;\n      transition: transform 0.3s;\n      transition: transform 0.3s, -webkit-transform 0.3s; }\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9uZy1ob3Jpem9udGFsLXRpbWVsaW5lLnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBV0E7RUFDRSxtQkFBa0IsRUF1RW5CO0VBeEVEO0lBSUksaUJBQWdCO0lBQ2hCLHFCQUFhO0lBQWIscUJBQWE7SUFBYixjQUFhO0lBQ2IsV0FBVTtJQUNWLDBCQUE4QjtRQUE5Qix1QkFBOEI7WUFBOUIsK0JBQThCLEVBNkMvQjtJQXBESDtNQVVNLDZCQUFzQjtNQUF0Qiw4QkFBc0I7VUFBdEIsMkJBQXNCO2NBQXRCLHVCQUFzQjtNQUN0QixhQUE2QixFQXdDOUI7TUFuREw7UUFjUSxzQkFBcUI7UUFDckIsZ0JBQWU7UUFDZixlQUFjLEVBa0NmO1FBbERQO1VBSkUsU0FBUTtVQUNSLG9DQUEyQjtrQkFBM0IsNEJBQTJCO1VBdUJuQixlQUFjO1VBQ2QsbUJBQWtCO1VBQ2xCLGFBQVk7VUFDWixXQS9CVTtVQWdDVixZQWhDVTtVQWlDViwwQkFuQ2dCO1VBb0NoQiwwQkFuQ2tCO1VBb0NsQixtQkFBa0IsRUFDbkI7UUE1QlQ7VUErQlUsMEJBMUNVO1VBMkNWLGFBQVk7VUFDWixZQXhDZ0M7VUF5Q2hDLGFBekNnQyxFQTBDakM7UUFuQ1Q7VUFzQ1UsbUJBQWtCO1VBQ2xCLGVBQWM7VUFDZCxXQUFVO1VBQ1YsWUFBVztVQUNYLHlCQUF1RDtVQUN2RCxvQ0FBMkI7a0JBQTNCLDRCQUEyQjtVQUMzQixtQkFBa0I7VUFDbEIsa0JBQWlCO1VBQ2pCLDBCQUF5QjtVQUN6QixzQkFBcUI7VUFDckIsc0JBQWE7Y0FBYixrQkFBYTtrQkFBYixjQUFhLEVBQ2Q7RUFqRFQ7SUF1REksZUFBYztJQUNkLG1CQUFrQjtJQUNsQixTQUFRO0lBQ1IsWUFBVyxFQWFaO0lBdkVIO01BNkRNLGVBQWM7TUFDZCxtQkFBa0I7TUFDbEIsWUFBVztNQUNYLFlBQVc7TUFDWCwwQkE1RWM7TUFPbEIsU0FBUTtNQUNSLG9DQUEyQjtjQUEzQiw0QkFBMkI7TUFzRXZCLDZCQUFvQjtjQUFwQixxQkFBb0I7TUFDcEIsc0NBQTZCO2NBQTdCLDhCQUE2QjtNQUM3QiwyQ0FBMEI7TUFBMUIsbUNBQTBCO01BQTFCLDJCQUEwQjtNQUExQixtREFBMEIsRUFDM0IiLCJmaWxlIjoibmctaG9yaXpvbnRhbC10aW1lbGluZS5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiJGJhc2UtY29sb3I6ICM3YjlkNmY7XHJcbiRiYXNlLWNsZWFyLWNvbG9yOiAjZjhmOGY4O1xyXG4kYmFzZS1pbmF0aXZlLWNvbG9yOiAjMzgzODM4O1xyXG4kZXZlbnQtZG90LXNpemU6IDdweDtcclxuJGV2ZW50LWRvdC1zaXplLWJpZzogJGV2ZW50LWRvdC1zaXplICsgM3B4O1xyXG5cclxuQG1peGluIHRvcC1hbmQtdHJhbnNsYXRlKCkge1xyXG4gIHRvcDogNTAlO1xyXG4gIHRyYW5zZm9ybTogdHJhbnNsYXRlWSgtNTAlKTtcclxufVxyXG5cclxuLnRpbWVsaW5lLWNvbnRhaW5lciB7XHJcbiAgcG9zaXRpb246IHJlbGF0aXZlO1xyXG5cclxuICBvbCB7XHJcbiAgICBsaXN0LXN0eWxlOiBub25lO1xyXG4gICAgZGlzcGxheTogZmxleDtcclxuICAgIHBhZGRpbmc6IDA7XHJcbiAgICBqdXN0aWZ5LWNvbnRlbnQ6IHNwYWNlLWJldHdlZW47XHJcblxyXG4gICAgbGkge1xyXG4gICAgICBmbGV4LWRpcmVjdGlvbjogY29sdW1uO1xyXG4gICAgICBoZWlnaHQ6ICRldmVudC1kb3Qtc2l6ZSArIDNweDtcclxuXHJcbiAgICAgIGEge1xyXG4gICAgICAgIHRleHQtZGVjb3JhdGlvbjogbm9uZTtcclxuICAgICAgICBjdXJzb3I6IHBvaW50ZXI7XHJcbiAgICAgICAgZGlzcGxheTogYmxvY2s7XHJcblxyXG4gICAgICAgICY6OmJlZm9yZSB7XHJcbiAgICAgICAgICBAaW5jbHVkZSB0b3AtYW5kLXRyYW5zbGF0ZSgpO1xyXG4gICAgICAgICAgZGlzcGxheTogYmxvY2s7XHJcbiAgICAgICAgICBwb3NpdGlvbjogYWJzb2x1dGU7XHJcbiAgICAgICAgICBjb250ZW50OiAnICc7XHJcbiAgICAgICAgICB3aWR0aDogJGV2ZW50LWRvdC1zaXplO1xyXG4gICAgICAgICAgaGVpZ2h0OiAkZXZlbnQtZG90LXNpemU7XHJcbiAgICAgICAgICBiYWNrZ3JvdW5kLWNvbG9yOiAkYmFzZS1jbGVhci1jb2xvcjtcclxuICAgICAgICAgIGJvcmRlcjogMXB4IHNvbGlkICRiYXNlLWluYXRpdmUtY29sb3I7XHJcbiAgICAgICAgICBib3JkZXItcmFkaXVzOiA1MCU7XHJcbiAgICAgICAgfVxyXG5cclxuICAgICAgICAmLnNlbGVjdGVkOjpiZWZvcmUge1xyXG4gICAgICAgICAgYmFja2dyb3VuZC1jb2xvcjogJGJhc2UtY29sb3I7XHJcbiAgICAgICAgICBib3JkZXI6IG5vbmU7XHJcbiAgICAgICAgICB3aWR0aDogJGV2ZW50LWRvdC1zaXplLWJpZztcclxuICAgICAgICAgIGhlaWdodDogJGV2ZW50LWRvdC1zaXplLWJpZztcclxuICAgICAgICB9XHJcblxyXG4gICAgICAgIHAge1xyXG4gICAgICAgICAgcG9zaXRpb246IGFic29sdXRlO1xyXG4gICAgICAgICAgZGlzcGxheTogYmxvY2s7XHJcbiAgICAgICAgICBwYWRkaW5nOiAwO1xyXG4gICAgICAgICAgd2lkdGg6IDUwcHg7XHJcbiAgICAgICAgICBtYXJnaW46ICgkZXZlbnQtZG90LXNpemUgKyAkZXZlbnQtZG90LXNpemUpIGF1dG8gYXV0byAwO1xyXG4gICAgICAgICAgdHJhbnNmb3JtOiB0cmFuc2xhdGVYKC00MCUpO1xyXG4gICAgICAgICAgdGV4dC1hbGlnbjogY2VudGVyO1xyXG4gICAgICAgICAgdGV4dC13cmFwOiBub3JtYWw7XHJcbiAgICAgICAgICBvdmVyZmxvdy13cmFwOiBicmVhay13b3JkO1xyXG4gICAgICAgICAgd29yZC13cmFwOiBicmVhay13b3JkO1xyXG4gICAgICAgICAgaHlwaGVuczogYXV0bztcclxuICAgICAgICB9XHJcbiAgICAgIH1cclxuICAgIH1cclxuICB9XHJcblxyXG4gIC5saW5lLWNvbnRhaW5lciB7XHJcbiAgICBkaXNwbGF5OiBibG9jaztcclxuICAgIHBvc2l0aW9uOiBhYnNvbHV0ZTtcclxuICAgIHRvcDogNTAlO1xyXG4gICAgd2lkdGg6IDEwMCU7XHJcblxyXG4gICAgLmZpbGxpbmctbGluZSB7XHJcbiAgICAgIGRpc3BsYXk6IGJsb2NrO1xyXG4gICAgICBwb3NpdGlvbjogcmVsYXRpdmU7XHJcbiAgICAgIHotaW5kZXg6IC0xO1xyXG4gICAgICBoZWlnaHQ6IDFweDtcclxuICAgICAgYmFja2dyb3VuZC1jb2xvcjogJGJhc2UtY29sb3I7XHJcbiAgICAgIEBpbmNsdWRlIHRvcC1hbmQtdHJhbnNsYXRlKCk7XHJcbiAgICAgIHRyYW5zZm9ybTogc2NhbGVYKDApO1xyXG4gICAgICB0cmFuc2Zvcm0tb3JpZ2luOiBsZWZ0IGNlbnRlcjtcclxuICAgICAgdHJhbnNpdGlvbjogdHJhbnNmb3JtIDAuM3M7XHJcbiAgICB9XHJcbiAgfVxyXG59XHJcbiJdfQ== */\n/*# sourceURL=src\\ng-horizontal-timeline.scss */\n"
module.exports = require('scssify').createStyle(css, {"href":"src\\ng-horizontal-timeline.scss"})
},{"scssify":1}],4:[function(require,module,exports){
(function (global){
"use strict";

Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.Timeline = undefined;

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }(); //@ts-check

var _jquery = (typeof window !== "undefined" ? window['$'] : typeof global !== "undefined" ? global['$'] : null);

var _jquery2 = _interopRequireDefault(_jquery);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var Timeline = exports.Timeline = function () {
    _createClass(Timeline, null, [{
        key: "toInt",
        value: function toInt(value) {
            return parseInt(value);
        }
    }]);

    function Timeline(timelineContainerElement) {
        _classCallCheck(this, Timeline);

        if (!timelineContainerElement) {
            throw TypeError("timelineContainerElement should not be null");
        }

        this.timelineContainerElement = (0, _jquery2.default)(timelineContainerElement);
        if (!this.timelineContainerElement.get(0)) {
            throw TypeError("timelineContainerElement should not be empty");
        }

        //cache timeline components 
        this.timelineEventsContainer = this.timelineContainerElement.children('.timeline-events');
        this.lineContainer = this.timelineContainerElement.children('.line-container');
        this.fillingLine = this.lineContainer.children('.filling-line');
    }

    _createClass(Timeline, [{
        key: "getEventLinks",
        value: function getEventLinks() {
            return this.timelineEventsContainer.find('.timeline-event-link');
        }
    }, {
        key: "onEventClick",
        value: function onEventClick(callback) {
            this.getEventLinks().on('click', callback);
        }
    }, {
        key: "offEventClick",
        value: function offEventClick(callback) {
            this.getEventLinks().off('click', callback);
        }
    }, {
        key: "setSelected",
        value: function setSelected(index) {
            var timelineEventLinks = this.getEventLinks();
            var elemSelect = (0, _jquery2.default)(timelineEventLinks.get(index));
            var eventsLenght = timelineEventLinks.length - 1;
            var scalePercentage = index / eventsLenght;

            timelineEventLinks.removeClass("selected");
            elemSelect.addClass("selected");

            this.fillingLine.css('transform', "scaleX(" + 1 + ")");
        }
    }]);

    return Timeline;
}();

}).call(this,typeof global !== "undefined" ? global : typeof self !== "undefined" ? self : typeof window !== "undefined" ? window : {})

},{}]},{},[2])

//# sourceMappingURL=ng-horizontal-timeline.js.map
