import { createMeal } from '../../../Model/Meal';
import React, { useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Title from '../Title/Title';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import EditIcon from '@material-ui/icons/Edit';

//Merely for demo
const rows = [
 createMeal(0, 'Sopa de Pedra', 'Sopa', 'Água, Pedra', 'Alho', '100 kcal'),
 createMeal(1, 'Arroz de frango', 'Dish', 'Arroz, Frango', 'Alho', '450 kcal'),
 createMeal(2, 'Sopa de Pedra', 'Sopa', 'Água, Pedra', 'Alho', '100 kcal'),
 createMeal(3, 'Sopa de Pedra', 'Sopa', 'Água, Pedra', 'Alho', '100 kcal'),
 createMeal(4, 'Sopa de Pedra', 'Sopa', 'Água, Pedra', 'Alho', '100 kcal'),
 createMeal(5, 'Sopa de Pedra', 'Sopa', 'Água, Pedra', 'Alho', '100 kcal'),
];

const useStyles = makeStyles(theme => ({
 button: {
  margin: theme.spacing(1),
 },
}));

export default function MealList() {
 const classes = useStyles();

 const [meals, setMeals] = useState([]);

 useEffect(() => {
  //TODO: Retrieve Meals from the API
  /*Example: var req = fetch(api_url/meals);
  var reqObj = JSON.parse(req);
  for(reqObj.Meal in reqObj){
   setMeals(meals + {reqObj.description, ...})
  }
  */
  setMeals(rows);
 }, []);

 return (
  <React.Fragment>
   <Title>Meals</Title>
   <Table size="small">
    <TableHead>
     <TableRow>
      <TableCell>Designation</TableCell>
      <TableCell>Meal Type</TableCell>
      <TableCell>Ingredients</TableCell>
      <TableCell>Allergens</TableCell>
      <TableCell>Descriptors</TableCell>
      <TableCell align="center">Actions</TableCell>
     </TableRow>
    </TableHead>
    <TableBody>
     {meals.map(row => (
      <TableRow key={row.id}>
       <TableCell>{row.designation}</TableCell>
       <TableCell>{row.mealType}</TableCell>
       <TableCell>{row.ingredients}</TableCell>
       <TableCell>{row.allergens}</TableCell>
       <TableCell>{row.descriptors}</TableCell>
       <TableCell align="center">
        <IconButton aria-label="edit" className={classes.margin}>
         <EditIcon fontSize="small" />
        </IconButton>
       </TableCell>
      </TableRow>
     ))}
    </TableBody>
   </Table>
   <div>
    <Button variant="contained" size="small" color="primary" className={classes.button}>
     Create Meal
    </Button>
   </div>
  </React.Fragment>
 );
}