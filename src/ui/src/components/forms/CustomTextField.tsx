import React from 'react';
import { TextField } from '@material-ui/core';
import { FormikProps } from 'formik';
import { IFieldConfig } from '../../interfaces/Forms/IFieldConfig';

export interface ICustomTextFieldProps<T> {
  field: IFieldConfig<T>;
  formik: FormikProps<T>;
}

function CustomTextField<T>({ field, formik }: ICustomTextFieldProps<T>) {
  const { id, name, label, type } = field;
  const error =
    formik.touched[name as keyof T] && formik.errors[name as keyof T];
  const helperText = error ? String(error) : '';

  return (
    <div className="w-9/12">
      <TextField
        id={id}
        name={name as string}
        label={label}
        type={type}
        variant="outlined"
        onChange={formik.handleChange}
        onBlur={formik.handleBlur}
        value={formik.values[name as keyof T]}
        error={!!error}
        helperText={helperText}
        className="w-full"
      />
    </div>
  );
}

export default CustomTextField;
