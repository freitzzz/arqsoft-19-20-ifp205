import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import React, { useEffect, useState } from 'react';
import { getData } from '../../../Controller/GetController';
import Title from '../Title/Title';

export function QueryItem() {
    
    const [mealList, setMealList] = useState([]);
    const [mealInfoList, setMealInfoList] = useState([{id: 1, name: 'Stone Soup', quantity: 5}, {id: 2, name: 'Kidney Stone Soup', quantity: 2}]);
    const header = ['Meal Name', "Quantity"].map((title) => { return (<TableCell>{title}</TableCell>) });;

    useEffect(() => {
        getData('meals').then(value => setMealList(value));
    });

    useEffect((mealList, mealInfoList) => {
        if (mealList && mealList.length) {
            for (const meal of mealList) {
                getData(`items?mealId=${meal.id}`).then(value => setMealInfoList([...mealInfoList,{id: meal.id, name: meal.designation, quantity: value}]));
            }
        }
    }, [mealList]);

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