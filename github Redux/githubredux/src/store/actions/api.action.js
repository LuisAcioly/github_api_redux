import api from './api';

async function loadRepositories(){
    return await api.request('GET /search/repositories', {
        q: 'q'
      }).then(function(response) {
        console.log("adasdadas")
        return response.data;
      }).then(function(data) {
        console.log("blablabla")
        return data;
      })
}

const repositories = loadRepositories();
console.log(repositories);

export default repositories;