import api from './api';

export default function loadRepositories(){
    return api.request('GET /search/repositories', {
        q: 'q'
      }).then(data => { return data; }).catch((erro) => { console.log(erro); });

}
