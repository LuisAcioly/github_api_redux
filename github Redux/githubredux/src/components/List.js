import { useHistory } from "react-router-dom";
import { useEffect, useState } from "react";
import { FaTimes } from 'react-icons/fa';
import github from '../assets/github.png';
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
        const res= result.repositories.filter((item) => {
            if(item.favorite){
                return item;
            }
        });

        setList(res);
    }


    function goBack() {
        history.push('/');
    }

    function unfavorite(item){
        const res = result.repositories;
        const resList = [...list];
        const index = res.findIndex(t => t.id === item.id);
        const indexList = list.findIndex(t => t.id === item.id);
        
        item.favorite = false;
        
        res.splice(index, 1, item);
        resList.splice(indexList, 1);

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
                                <img src={github} />
                                {item.name}<br/>
                                {item.login}
                            </div>
                        </li>
                    })}
                </ul>
            </div>
        </div>
    );
}

export default List;