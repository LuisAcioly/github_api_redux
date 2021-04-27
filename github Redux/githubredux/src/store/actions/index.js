export function favorite(request){
    return { 
        type: 'FAVORITE',
        repositories: request,
    }
}