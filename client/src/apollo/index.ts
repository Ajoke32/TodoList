import {ApolloClient, InMemoryCache, from, createHttpLink} from '@apollo/client';
import { removeTypenameFromMutationLink } from 'apollo-remove-typename-mutation-link';


const httpLink = createHttpLink({ uri:'http://localhost:5266/tasks'});

const link = from([removeTypenameFromMutationLink,httpLink]);

export const todoClient = new ApolloClient({
    cache: new InMemoryCache(),
    link
});



