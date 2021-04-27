function repositoryClass(name, login, id) {
    this.name = name;
    this.login = login;
    this.id = id;
    this.favorite = false;
}

export function saveRepositories(data){
    
    var array = [];

    Object.keys(data).forEach(
        function(item){
            array.push(data[item]);
        }
    )

    var resultList = [];

    array.forEach(
        function(item){
            var repository = new repositoryClass(item.name, item.owner.login, item.id);
            resultList.push(repository);
        }
    );

    return {
        type: 'SAVE_REPOSITORIES',
        repositories: resultList,
        unloaded: false,
    }
}

export function favorite(request){
    return { 
        type: 'FAVORITE',
        repositories: request,
    }
}
