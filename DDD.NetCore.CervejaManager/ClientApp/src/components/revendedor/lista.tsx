import * as React from 'react';
import { connect } from 'react-redux';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';
import { ApplicationState } from '../../store';
import * as RevendedorStore from '../../store/Revendedor';

// At runtime, Redux will merge together...
type RevendedorProps =
    RevendedorStore.RevendedorState // ... state we've requested from the Redux store
    & typeof RevendedorStore.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{}>; // ... plus incoming routing parameters


class ListaRevendedor extends React.PureComponent<RevendedorProps> {
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
                <h1 id="listaRevendedors">Revendedores</h1>
                <p>Revendedores disponíveis</p>
                {this.renderTable()}
            </React.Fragment>
        );
    }

    private ensureDataFetched() {
        this.props.requestRevendedors();
    }

    private renderTable() {
        return (
            <table className='table table-striped' aria-labelledby="tableRevendedors">
                <thead>
                    <tr>
                        <th>Nome</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.revendedores.map((item: RevendedorStore.Revendedor) =>
                        <tr key={item.nome}>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
}

export default connect(
    (state: ApplicationState) => state.revendedores, // Selects which state properties are merged into the component's props
    RevendedorStore.actionCreators // Selects which action creators are merged into the component's props
)(ListaRevendedor as any);
