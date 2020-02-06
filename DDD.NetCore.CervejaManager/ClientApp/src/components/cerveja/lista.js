"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_redux_1 = require("react-redux");
var CervejaStore = require("../../store/Cerveja");
var ListaCerveja = /** @class */ (function (_super) {
    __extends(ListaCerveja, _super);
    function ListaCerveja() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    // This method is called when the component is first added to the document
    ListaCerveja.prototype.componentDidMount = function () {
        this.ensureDataFetched();
    };
    // This method is called when the route parameters change
    ListaCerveja.prototype.componentDidUpdate = function () {
        this.ensureDataFetched();
    };
    ListaCerveja.prototype.render = function () {
        return (React.createElement(React.Fragment, null,
            React.createElement("h1", { id: "listaCervejas" }, "Cervejas"),
            React.createElement("p", null, "Cervejas dispon\u00EDveis"),
            this.renderTable()));
    };
    ListaCerveja.prototype.ensureDataFetched = function () {
        this.props.requestCervejas();
    };
    ListaCerveja.prototype.renderTable = function () {
        return (React.createElement("table", { className: 'table table-striped', "aria-labelledby": "tableCervejas" },
            React.createElement("thead", null,
                React.createElement("tr", null,
                    React.createElement("th", null, "Nome"),
                    React.createElement("th", null, "Teor Alc\u00F3olico"),
                    React.createElement("th", null, "Pre\u00E7o"))),
            React.createElement("tbody", null, this.props.cervejas.map(function (item) {
                return React.createElement("tr", { key: item.nome },
                    React.createElement("td", null, item.teorAlcoolico),
                    React.createElement("td", null, item.preco));
            }))));
    };
    return ListaCerveja;
}(React.PureComponent));
exports.default = react_redux_1.connect(function (state) { return state.cervejas; }, // Selects which state properties are merged into the component's props
CervejaStore.actionCreators // Selects which action creators are merged into the component's props
)(ListaCerveja);
//# sourceMappingURL=lista.js.map