import {gql} from "@apollo/client";


export const createCategoryMutation = gql`
mutation CreateCategory($title:String!){
  category{
    createCategory(category:{title:$title}){
      id,
      title
    }
  }
}
`;