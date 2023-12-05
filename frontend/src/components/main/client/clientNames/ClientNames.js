import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { getTimesheetAsync } from "../../../../redux/timsheetSlice";
import Person from "./person/Person";

const ClientNames = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getTimesheetAsync([]));
  }, [dispatch]);

  const clients = useSelector((state) => state.timesheet);


  return (
    <div class="accordion-wrap clients">
      {clients.map((client) => (
        <div key={client.id}>
          <Person
            names={client.name}
            city={client.city}
            address={client.address}
            country={client.country}
          />
        </div>
      ))}
    </div>
  );
};

export default ClientNames;
