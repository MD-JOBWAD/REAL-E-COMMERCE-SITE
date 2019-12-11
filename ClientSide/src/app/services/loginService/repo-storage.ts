import{ Injectable } from "@angular/core";

@Injectable()
export class RepoStorage {

    //Method For Add or update Web storage data

    addUpdateLocal( keyName: string , data: any):any{
        if(data == JSON){
            localStorage.setItem(keyName, JSON.stringify(data))     
        }
        else{
        localStorage.setItem(keyName, data)
        } 
    }
    addUpdateSession(keyName: string , data: any ):any{
        if(data == JSON){
            sessionStorage.setItem(keyName, JSON.stringify(data))     
        }
        else{
        sessionStorage.setItem(keyName, data)
        } 
    }


    //Method For Get Web storage data
    getLocal(keyName : string):any{
        if(localStorage.getItem(keyName).toString()){
             return localStorage.getItem(keyName)
        }
        else{
            return   JSON.parse(localStorage.getItem(keyName)) 
        } 
    }
    getSession(keyName : string):any{
        if(!sessionStorage.getItem(keyName).toString()){
         return sessionStorage.getItem(keyName);   
        }
        else{
            return   JSON.parse(sessionStorage.getItem(keyName))  
        } 
    }

    //Method For Remove Web storage data

    removeLocal(keyName : string):any{
        
     return  localStorage.removeItem(keyName)
    }

    removeSession(keyName : string):any{
        return  sessionStorage.removeItem(keyName)
    }

    //Method For Remove All Web storage data
    removeAllLocal(keyName : string):any{
        
        return  localStorage.clear()
       }
   
    removeAllSession(keyName : string):any{
           return  sessionStorage.clear()
       }
   
}
