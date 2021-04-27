import api from './api';

export default function loadRepositories(query, type){
  var response;
    if(type === 'repositories'){
      response = api.request(`GET /search/${type}?`, {
        q: `${query}`
      }).then(data => { return data.data.items; }).catch((erro) => { console.log(erro); });
    }
    else{
      response = api.request(`GET /${type}/${query}/repos`).then(data => { return data.data; }).catch((erro) => { console.log(erro); });
    }

    return response;
}
