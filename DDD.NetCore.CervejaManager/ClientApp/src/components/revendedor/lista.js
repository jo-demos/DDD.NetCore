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
var RevendedorStore = require("../../store/Revendedor");
var ListaRevendedor = /** @class */ (function (_super) {
    __extends(ListaRevendedor, _super);
    function ListaRevendedor() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    // This method is called when the component is first added to the document
    ListaRevendedor.prototype.componentDidMount = function () {
        this.ensureDataFetched();
    };
    // This method is called when the route parameters change
    ListaRevendedor.prototype.componentDidUpdate = function () {
        this.ensureDataFetched();
    };
    ListaRevendedor.prototype.render = function () {
        return (React.createElement(React.Fragment, null,
            React.createElement("h1", { id: "listaRevendedors" }, "Revendedores"),
            React.createElement("p", null, "Revendedores dispon\u00EDveis"),
            this.renderTable()));
    };
    ListaRevendedor.prototype.ensureDataFetched = function () {
        this.props.requestRevendedors();
    };
    ListaRevendedor.prototype.renderTable = function () {
        return (React.createElement("table", { className: 'table table-striped', "aria-labelledby": "tableRevendedors" },
            React.createElement("thead", null,
                React.createElement("tr", null,
                    React.createElement("th", null, "Nome"))),
            React.createElement("tbody", null, this.props.revendedores.map(function (item) {
                return React.createElement("tr", { key: item.nome });
            }))));
    };
    return ListaRevendedor;
}(React.PureComponent));
exports.default = react_redux_1.connect(function (state) { return state.revendedores; }, // Selects which state properties are merged into the component's props
RevendedorStore.actionCreators // Selects which action creators are merged into the component's props
)(ListaRevendedor);
//# sourceMappingURL=lista.js.map