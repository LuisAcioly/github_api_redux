import '../style/head.css';
import { useSelector } from 'react-redux'

function Head(){
    const list = useSelector(state => state.repositories)

    return (
        <div className="head">
            <div className="head-link"><button>Meus favoritos</button></div>
            <div className="forms">
                <form>
                    <select name="type" style={{height: 21, marginRight: 2}}>
                        <option value="repository">
                            Repósitorio
                        </option>
                    </select>
                    <input name="name"/>
                    <button style={{marginBottom: 20, marginLeft: 5}} type="submit">Buscar</button>
                </form>
            </div>
        </div>
    );
}

function mapStateToProps (state){
    return {
        result: state.repositories,
    }
}

export default Head;