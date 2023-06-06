import {gql} from "@apollo/client";


export const  getAllTaskQuery = gql`
query{
  todo{
    tasks{
      id,
      categoryId,
      title,
      expirationDate,
      isCompleted
    }
  }
}
`