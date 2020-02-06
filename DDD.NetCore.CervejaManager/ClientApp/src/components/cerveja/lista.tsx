import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../../store';
import * as CervejaStore from '../../store/Cerveja';

// At runtime, Redux will merge together...
type CervejaProps =
    CervejaStore.CervejaState // ... state we've requested from the Redux store
    & typeof CervejaStore.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{ }>; // ... plus incoming routing parameters


class ListaCerveja extends React.PureComponent<CervejaProps> {
    // This method is called when the component is first added to the document
    public componentDidMount() {
        this.ensureDataFetched();
    }

    // This method is called when the route parameters change
    public componentDidUpdate() {
        this.ensureDataFetched();
    }

    public render() {
        return (
            <React.Fragment>
                <h1 id="listaCervejas">Cervejas</h1>
                <p>Cervejas disponíveis</p>
                {this.renderTable()}
            </React.Fragment>
        );
    }

    private ensureDataFetched() {
        this.props.requestCervejas();
    }

    private renderTable() {
        return (
            <table className='table table-striped' aria-labelledby="tableCervejas">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Teor Alcóolico</th>
                        <th>Preço</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.cervejas.map((item: CervejaStore.Cerveja) =>
                        <tr key={item.nome}>
                            <td>{item.teorAlcoolico}</td>
                            <td>{item.preco}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}

export default connect(
    (state: ApplicationState) => state.cervejas, // Selects which state properties are merged into the component's props
    CervejaStore.actionCreators // Selects which action creators are merged into the component's props
)(ListaCerveja as any);
