import { createRouter } from 'vue-router'
import { SignInComponent } from './user/';

const routes = [
    {
        path: '/login/',
        component: SignInComponent
    },
]

export default function (history) {
    return createRouter({
        history,
        routes
    })
}