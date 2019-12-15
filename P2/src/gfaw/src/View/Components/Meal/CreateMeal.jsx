import React, { useState, useEffect } from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import { Chip, Select, FormControl, MenuItem, InputLabel, Input } from '@material-ui/core';
import { postData } from '../../../Controller/PostController';
import { makeStyles } from '@material-ui/core/styles';
import { getData } from '../../../Controller/GetController';

const useStyles = makeStyles(theme => ({
  button: {
    margin: theme.spacing(1),
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 120,
    maxWidth: 300,
  },
  chips: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  chip: {
    margin: 2,
  },
  noLabel: {
    marginTop: theme.spacing(3),
  },
  textField: {
    margin: theme.spacing(1),
  }
}));

export default function CreateMeal(props) {
  const classes = useStyles();
  // To feed the comboboxes
  const [ingredientList, setIngredientList] = useState([]);
  const [allergenList, setAllergenList] = useState([]);
  const [mealTypeList, setMealTypeList] = useState([]);
  const [descriptorList, setDescriptorList] = useState([]);
  // Only to support the descriptor weight units
  const [unitList, setUnitList] = useState([]);

  //dialog inputs
  const [designation, setDesignation] = useState('');
  const [mealType, setMealType] = useState('');
  const [ingredients, setIngredients] = useState([]);
  const [allergens, setAllergens] = useState([]);
  const [quantity, setQuantity] = useState();
  const [quantityUnit, setQuantityUnit] = useState();
  const [name, setName] = useState();
  const [descriptors, setDescriptors] = useState([]);

  const handleCloseCreateMealDialog = () => {
    setName(null);
    setDesignation(null);
    setIngredients([]);
    setAllergens([]);
    setDescriptors([]);
    setQuantity('');
    setQuantityUnit(null);
    props.close();
  }

  const handleSubmitCreateMealDialog = () => {
    //send data
    postData('meals', JSON.stringify({
      designation: designation,
      type: mealType.name,
      ingredients: ingredients.map(i => i.name),
      allergens: allergens.map(a => a.name),
      descriptors: descriptors
    }));
    setName(null);
    setDesignation(null);
    setIngredients([]);
    setAllergens([]);
    setDescriptors([]);
    setQuantity('');
    setQuantityUnit(null);
    props.close();
  }

  const handleCreateDesignation = event => {
    setDesignation(event.target.value);
  };

  const handleCreateIngredient = event => {
    setIngredients(event.target.value);
  };

  const handleCreateMealType = (event) => {
    setMealType(event.target.value);
  }

  const handleCreateAllergen = event => {
    setAllergens(event.target.value);
  };

  const handleCreateDescriptor = () => {
    setDescriptors([...descriptors, { quantity: parseFloat(quantity), quantityUnit: quantityUnit, name: name }]);
  }

  const handleRemoveDescriptor = descriptor => () => {
    setDescriptors(descriptors => descriptors.filter(descriptorItem => descriptorItem !== descriptor));
  }

  const handleCreateQuantity = (event) => {
    setQuantity(event.target.value);
  }

  const handleCreateQuantityUnit = (event) => {
    setQuantityUnit(event.target.value);
  }

  const handleCreateName = (event) => {
    setName(event.target.value.name);
    setUnitList(event.target.value.quantityUnits);
  }

  useEffect(() => {
    getData('mealtypes').then(value => setMealTypeList(value));
    getData('ingredients').then(value => setIngredientList(value));
    getData('allergens').then(value => setAllergenList(value));
    getData('descriptors').then(value => setDescriptorList(value));
  }, []);

  // Dropdown list initialization
  const ingredientOptions = ingredientList && ingredientList.length ? ingredientList
    .map((ingredient) => { return (<MenuItem key={ingredient.id} value={ingredient}>{ingredient.name}</MenuItem>) }) : <MenuItem>Nothing Here</MenuItem>;

  const mealTypeOptions = mealTypeList && mealTypeList.length ? mealTypeList
    .map((mealType) => { return (<MenuItem key={mealType.id} value={mealType}>{mealType.name}</MenuItem>) }) : <MenuItem>Nothing Here</MenuItem>;

  const allergenOptions = allergenList && allergenList.length ? allergenList
    .map((allergen) => { return (<MenuItem key={allergen.id} value={allergen}>{allergen.name}</MenuItem>) }) : <MenuItem>Nothing Here</MenuItem>;

  const descriptorOption = descriptorList && descriptorList.length ? descriptorList
    .map((descriptor) => { return (<MenuItem key={descriptor.id} value={descriptor}>{descriptor.name}</MenuItem>) }) : <MenuItem>Nothing Here</MenuItem>;

  const unitOption = unitList && unitList.length ? unitList
    .map((unit) => { return (<MenuItem key={unit} value={unit}>{unit}</MenuItem>) }) : <MenuItem>Nothing Here</MenuItem>;

  const descriptorChips = descriptors ? descriptors.map((descriptor) => { return (<Chip value={descriptor} onDelete={handleRemoveDescriptor(descriptor)} label={`${descriptor.name} ${descriptor.quantity} ${descriptor.quantityUnit}`} />) }) : null;

  return (
    <Dialog open={props.open} aria-labelledby="form-dialog-title">
      <DialogTitle id="form-dialog-title">Create Meal</DialogTitle>
      <DialogContent>
        <div>
          <TextField autoFocus margin="dense" id="designation" label="Designation" fullWidth className={classes.textField} onChange={handleCreateDesignation} />
          <div>
            <FormControl className={classes.formControl} >
              <InputLabel id="meal_type_label">Meal Type</InputLabel>
              <Select id="meal_type" labelId="meal_type_label" onChange={handleCreateMealType} value={mealType} >
                {mealTypeOptions}
              </Select>
            </FormControl>
          </div>
          <div>
            <FormControl className={classes.formControl}>
              <InputLabel id="demo-mutiple-chip-label">Ingredients</InputLabel>
              <Select
                labelId="demo-mutiple-chip-label"
                id="demo-mutiple-chip"
                multiple
                value={ingredients}
                onChange={handleCreateIngredient}
                input={<Input id="select-multiple-chip" />}
                renderValue={selected => (
                  <div className={classes.chips}>
                    {selected.map(value => (
                      <Chip key={value.id} label={value.name} />
                    ))}
                  </div>
                )}
              >
                {ingredientOptions}
              </Select>
            </FormControl>
          </div>
          <div>
            <FormControl className={classes.formControl}>
              <InputLabel id="demo-mutiple-chip-label">Allergens</InputLabel>
              <Select
                labelId="demo-mutiple-chip-label"
                id="demo-mutiple-chip"
                multiple
                value={allergens}
                onChange={handleCreateAllergen}
                input={<Input id="select-multiple-chip" />}
                renderValue={selected => (
                  <div className={classes.chips}>
                    {selected.map(value => (
                      <Chip key={value.id} label={value.name} />
                    ))}
                  </div>
                )}
              >
                {allergenOptions}
              </Select>
            </FormControl>
          </div>
          <div>
            <FormControl className={classes.formControl} >
              <InputLabel id="descriptor_label">Content</InputLabel>
              <Select id="descriptor" labelId="descriptor_label" onChange={handleCreateName} >
                {descriptorOption}
              </Select>
            </FormControl>
            <FormControl className={classes.formControl} >
              <InputLabel id="unit_label">Unit</InputLabel>
              <Select id="unit" labelId="unit_label" onChange={handleCreateQuantityUnit} >
                {unitOption}
              </Select>
            </FormControl>
            <TextField autoFocus margin="dense" id="quantity" label="Quantity" onChange={handleCreateQuantity} />
            <Button color="primary" onClick={handleCreateDescriptor}>Add Descriptor</Button>
          </div>
          <div>
            {descriptorChips}
          </div>
        </div>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleCloseCreateMealDialog} color="primary">
          Cancel
            </Button>
        <Button onClick={handleSubmitCreateMealDialog} color="primary">
          Submit
            </Button>
      </DialogActions>
    </Dialog>
  );
}