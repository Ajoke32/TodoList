import {gql} from "@apollo/client";

export const updateTaskMutation = gql`mutation UpdateTask($task:updateTask!) {
  todo {
    updateTask(
      task: $task
    ) {
      id
      title
      expirationDate
      isCompleted
      categoryId
    }
  }
}`

export const removeTaskMutation = gql`
mutation RemoveTask($id:Int!) {
  todo{
    removeTask(taskId:$id)
  }
}
`

export const createTaskMutations = gql`
mutation CreateTask($task:taskInput!){
  todo{
    createTask(task: $task) {
    id
    title
    expirationDate
    isCompleted
    categoryId
    }
  }
}
`