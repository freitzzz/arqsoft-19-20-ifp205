import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import React, { useEffect, useState } from 'react';
import { getData } from '../../../Controller/GetController';
import Title from '../Title/Title';

export function QueryItem() {
    
    const [mealInfoList, setMealInfoList] = useState([]);
    const header = ['Meal Name', 'Quantity'].map((title) => { return (<TableCell>{title}</TableCell>) });;

    useEffect(() => {
        getData('meals').then(function(meals){
            meals.forEach(function (meal) {
                getData('items?mealId=' + meal.id).then(function(quantity){
                    setMealInfoList(mealInfoList => [...mealInfoList,{id: meal.id, name: meal.designation, quantity: quantity.length}]);
                });
            });
        });
    }, []);

    return (
        <React.Fragment>
            <Title>
                Meal Information
            </Title>
            <Table>
                <TableHead>
                    <TableRow>
                        {header}
                    </TableRow>
                </TableHead>
                <TableBody>
                    {mealInfoList && mealInfoList.length ? mealInfoList.map(row => (
                        <TableRow key={row.id}>
                            <TableCell>{row.name}</TableCell>
                            <TableCell>{row.quantity}</TableCell>
                        </TableRow>
                    )) : null}
                </TableBody>
            </Table>
        </React.Fragment>
    )

}