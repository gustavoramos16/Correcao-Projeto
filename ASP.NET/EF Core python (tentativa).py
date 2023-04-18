from sqlalchemy import create_engine

user = 'gu07ramos'
password = '1234'
host = 'localhost'  
database = 'empresarial'

connection_string = f'mysql://{user}:{password}@{host}/{database}'

print(connection_string)