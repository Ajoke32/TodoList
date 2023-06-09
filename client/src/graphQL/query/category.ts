import {gql} from "@apollo/client";


export const getAllGategoriesQuery = gql`
query{
  category{
    categories{
      id,
      title
    }
  }
}
`