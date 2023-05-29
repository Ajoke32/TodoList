import  * as TodoActionCreators from './todo'
import  * as CategoryActionCreators from './category'
export default {
    ...TodoActionCreators,
    ...CategoryActionCreators
}