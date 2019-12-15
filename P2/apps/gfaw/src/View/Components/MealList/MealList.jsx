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
import { getData } from '../../../Controller/GetController';
import CreateMeal from '../Meal/CreateMeal';


const useStyles = makeStyles(theme => ({
  button: {
    margin: theme.spacing(1),
  }
}));

export default function MealList() {
  const classes = useStyles();
  const header = ['Designation', 'Actions']
    .map((title) => { return (<TableCell>{title}</TableCell>) });

  //dialog
  const [open, setOpen] = React.useState(false);
  //meal List
  const [meals, setMeals] = useState([]);

  const handleCreateMealDialog = () => {
    setOpen(!open);
  }

  const handleCloseCreateMealDialog = () => {
    setOpen(false);
  }

  useEffect(() => {
    if(!open){
      getData('meals').then(value => setMeals(value));
    }
  }, [open]);

  return (
    <React.Fragment>
      <Title>Meals</Title>
      <Table size="small">
        <TableHead>
          <TableRow>
            {header}
          </TableRow>
        </TableHead>
        <TableBody>
          {meals && meals.length ? meals.map(row => (
            <TableRow key={row.id}>
              <TableCell>{row.designation}</TableCell>
              <TableCell>
                <IconButton aria-label="edit" className={classes.margin}>
                  <EditIcon fontSize="small" />
                </IconButton>
              </TableCell>
            </TableRow>
          )) : null}
        </TableBody>
      </Table>
      <div>
        <Button size="small" color="primary" className={classes.button} onClick={handleCreateMealDialog}>
          Create Meal
        </Button>
      </div>
      <CreateMeal open={open} close={handleCloseCreateMealDialog}/>
    </React.Fragment>
  );
}
