import {gql} from "@apollo/client";

export const updateTaskMutation = gql`mutation UpdateTask($task:updateTask!){
  updateTask(task: $task){
    id,
    categoryId,
    title,
    isCompleted,
    expirationDate
  }
}`

export const removeTaskMutation = gql`
mutation RemoveTask($id:Int!) {
  removeTask(taskId: $id)
}
`