import '../style/head.css';
import { useDispatch, useSelector } from "react-redux";
import React, { useEffect, useState } from 'react';
import loadRepositories from '../services/api.service';
import { saveRepositories, favorite } from '../store/actions/index';
import { FaRegStar, FaStar } from 'react-icons/fa';
import github from '../assets/github.png';
import { useHistory } from "react-router-dom";

const Head = () => {

    const [list, setList] = useState([]);
    const dispatch = useDispatch();
    const result  = useSelector((s) => s.common);
    const history = useHistory();
    
    async function getList() {
        const response = await loadRepositories();  
        dispatch(saveRepositories(response.data.items)); 
    }

    useEffect (() => {
        if(result.unloaded){
            getList();
        }
    }, [])

    function Search(e){
        e.preventDefault();
        console.log(e.target.name.value);
        const res = result.repositories.filter((item) => {
            if(item.name.indexOf(e.target.name.value) > -1){
                return item;
            }
        });

        setList(res);
    }

    function favor(item){
        const res = result.repositories;
        const resList = [...list];
        const index = res.findIndex(t => t.id === item.id);
        const indexList = list.findIndex(t => t.id === item.id);
        
        if(item.favorite === false){
            item.favorite = true;
        }
        else{
            item.favorite = false;
        }
        
        res.splice(index, 1, item);
        resList.splice(indexList, 1, item);

        setList(resList);
        dispatch(favorite(res)); 
    }

    function callFavorites(){
        history.push('/favorites');
    }

    return (
        <div className="head">
            <div className="head-link"><button onClick={callFavorites}>Meus favoritos</button></div>
            <div className="forms">
                <form onSubmit={Search}>
                    <select name="type" style={{height: 21, marginRight: 2}}>
                        <option value="repository">
                            Repósitorio
                        </option>
                    </select>
                    <input name="name"/>
                    <button style={{marginBottom: 20, marginLeft: 5}} type="submit">Buscar</button>
                </form>
            </div>
            <div className="list">
                <ul>
                    {list.map((item, index) => {
                        return <li key={index} style={{marginBottom: 50}}>
                            <div className="favorite">
                                <button onClick={() => favor(item)}>
                                    {item.favorite === false ? <FaRegStar/> : <FaStar/>}
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

export default Head;