# GBS_M151

[![](https://img.shields.io/badge/School-GBSSG-green)](https://www.gbssg.ch)
[![](https://img.shields.io/badge/ICT--Module-151-blue)](https://www.modulbaukasten.ch/module/151/3/de-DE?title=Datenbanken-in-Web-Applikation-einbinden)
![](https://img.shields.io/badge/Semester-6-blue)

:arrow_right: [Tasks](#tasks)

## Environment

```bash
cp -n .env.dist .env

docker-compose up -d
```

<details>
    <summary>Connection Details</summary>
    <strong>Host:</strong> <code>localhost,14330</code><br />
    <strong>Username:</strong> <code>sa</code><br />
    <strong>Password:</strong> <code>DEV_1234</code><br />
    <hr />
    <strong>Connection String:</strong> <code>Server=localhost,14330;Database=Northwind;User Id=sa;Password=DEV_1234;</code>
</details>
<br />

## Requirement

:arrow_right: install `System.Data.SqlClient`

## Tasks

| Task                | Description                  |
| ------------------- | ---------------------------- |
| [Task01](./Task01/) | `SqlConnection`              |
| [Task02](./Task02/) | `SqlConnectionStringBuilder` |
| [Task03](./Task03/) | `using () { ... }`           |
| [Task04](./Task04/) | `Pooling`                    |
| [Task05](./Task05/) | `Procedures`                 |
| [Task06](./Task06/) | `DML & DQL`                  |
| [Task07](./Task07/) | `Query Parameters`           |
| [Task08](./Task08/) | `Async & Polling`            |
