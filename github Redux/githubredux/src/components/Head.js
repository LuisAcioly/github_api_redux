import '../style/head.css';
import { useDispatch, useSelector } from "react-redux";
import React, { useEffect, useState } from 'react';
import loadRepositories from '../services/api.service';
import { favorite } from '../store/actions/index';
import { FaRegStar, FaStar } from 'react-icons/fa';
import { useHistory } from "react-router-dom";

const Head = () => {

    function repositoryClass(name, login, img, id) {
        this.name = name;
        this.login = login;
        this.img = img;
        this.id = id;
        this.favorite = false;
    }

    const [list, setList] = useState([]);
    const dispatch = useDispatch();
    const result  = useSelector((s) => s.common);
    const history = useHistory();

    async function getList(query, type) {
        const response = await loadRepositories(query, type);
        setRepositories(response);
    }

    async function Search(e){
        e.preventDefault();
        getList(e.target.name.value, e.target.type.value);
    }

    function setRepositories(data){
        var array = [];
        Object.keys(data).forEach(
            function(item){
                array.push(data[item]);
            }
        )

        var resultList = [];

        array.forEach(
            function(item){
                var repository = new repositoryClass(item.name, item.owner.login, item.owner.avatar_url, item.id);

                if(verify(repository) === true) {
                    
                    repository.favorite = true;
                }
                else{
                    repository.favorite = false;
                }
                resultList.push(repository);
            }
        );
        setList(resultList);

    }

    function favor(item){
        const res = result.repositories;
        const resList = [...list];
        const listIndex = resList.findIndex(p => p.id == item.id);
        const index = res.findIndex(p => p.id == item.id);
        console.log(index);
        console.log(res);
        console.log(item);

        if(item.favorite === false){
            item.favorite = true;
            res.push(item);
        }
        else{
            console.log("retirou");
            item.favorite = false;
            res.splice(index, 1);
        }
        
        resList.splice(listIndex, 1, item);
        setList(resList);

        dispatch(favorite(res)); 
    }

    function callFavorites(){
        history.push('/favorites');
    }

    function verify(repository){
        var item = repository;
        item.favorite = true;
        const res = result.repositories.find(element => element.id === item.id);

        if(res !== undefined){
            return true;
        }
        return false;
    }

    return (
        <div className="head">
            <div className="head-link"><button onClick={callFavorites}>Meus favoritos</button></div>
            <div className="forms">
                <form onSubmit={Search}>
                    <select name="type" style={{height: 21, marginRight: 2}}>
                        <option value="repositories">
                            Repósitorio
                        </option>
                        <option value="users">
                            Usuários
                        </option>
                    </select>
                    <input name="name" required/>
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

export default Head;