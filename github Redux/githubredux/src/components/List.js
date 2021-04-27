import { useHistory } from "react-router-dom";
import { useEffect, useState } from "react";
import { FaTimes } from 'react-icons/fa';
import { favorite } from '../store/actions/index';
import { useDispatch, useSelector } from "react-redux";
import '../style/head.css';

const List = () => {
    const [list, setList] = useState([]);
    const dispatch = useDispatch();
    const result  = useSelector((s) => s.common);
    const history = useHistory();

    useEffect (() => {
        getList();
    }, [])

    function getList() {
        const res= result.repositories;

        setList(res);
    }


    function goBack() {
        history.push('/');
    }

    function unfavorite(item){
        const res = result.repositories;
        const resList = [...list];
        const index = list.findIndex(p => p.id === item.id);
        
        res.splice(index, 1);
        resList.splice(index, 1);

        setList(resList);
        
        dispatch(favorite(res)); 
    }

    return (
        <div className="App">
            <div className="headFav"><button onClick={goBack}>Voltar</button></div>
            <div className="list">
                <ul>
                    {list.map((item, index) => {
                        return <li key={index} style={{marginBottom: 50}}>
                            <div className="favorite">
                                <button onClick={() => unfavorite(item, index)}>
                                    <FaTimes/>
                                </button>
                            </div>
                            <div className="res">
                                <img alt="image" src={item.img} />
                                {item.name}<br/>
                                <b style={{marginTop: 5}}>{item.login}</b>
                            </div>
                        </li>
                    })}
                </ul>
            </div>
        </div>
    );
}

export default List;